using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using PokemonLikeCsharp.Model;

namespace PokemonLikeCsharp.MVVM.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        
        public ICommand RequestDatabaseViewCommand { get; set; }
        public ICommand LoginCommand { get; }
        public ICommand SignupCommand { get; }
        public ICommand ExitCommand { get; }
        public string Database { get; set; }


        private ExercicesMonstersContext _context;
        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(Login);
            SignupCommand = new RelayCommand(Signup);
            ExitCommand = new RelayCommand(Exit);
            RequestDatabaseViewCommand = new RelayCommand(HandleRequestDatabaseCommand);
        }

        
        private string _username;
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        // Méthodes pour gérer les actions
        public void Login()
        {
            if (_context == null)
            {
                MessageBox.Show("Veuillez d'abord vous connecter à la base de données.");
                return;
            }

            var user = _context.Logins.SingleOrDefault(u => u.Username == Username);
            if (user != null && VerifyPassword(Password, user.PasswordHash))
            {
                string connectionString = _context.Database.GetConnectionString();
                if (connectionString == null)
                {
                    MessageBox.Show("Chaîne de connexion non valide.");
                    return;
                }

                var playerMonstersWindow = new PlayerMonstersWindow(Username, connectionString);
                playerMonstersWindow.Show();
            }
            else
            {
                MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect");
            }
        }



        public void Signup()
        {
            if (_context == null)
            {
                MessageBox.Show("Veuillez d'abord vous connecter à la base de données.");
                return;
            }

            if (_context.Logins.Any(u => u.Username == Username))
            {
                MessageBox.Show("Nom d'utilisateur déjà pris");
                return;
            }

            var newUser = new Login { Username = Username };
            newUser.PasswordHash = HashPassword(Password);
            _context.Logins.Add(newUser);
            _context.SaveChanges();

            var newPlayer = new Player { Name = Username, LoginId = newUser.Id };
            _context.Players.Add(newPlayer);
            _context.SaveChanges();

            MessageBox.Show("Compte créé avec succès !");
        }

        public void HandleRequestDatabaseCommand()
        {
            if (!string.IsNullOrEmpty(Database))
            {
                try
                {
                    App.ConnectionString = Database;

                    _context = new ExercicesMonstersContext(App.ConnectionString);

                    if (_context.Database.CanConnect())
                    {
                        MessageBox.Show("Connexion réussie à la base de données.", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        throw new Exception("La connexion au serveur a échoué. La chaîne de connexion peut être incorrecte.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur : {ex.Message}\nChaîne de connexion : {Database}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    _context = null;
                }
            }
            else
            {
                MessageBox.Show("Veuillez entrer une chaîne de connexion valide.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        public void Exit()
        {
            Application.Current.Shutdown();
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedPassword = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedPassword);
            }
        }

        private bool VerifyPassword(string inputPassword, string storedHash)
        {
            var hashedInputPassword = HashPassword(inputPassword);
            return hashedInputPassword == storedHash;
        }

    
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
