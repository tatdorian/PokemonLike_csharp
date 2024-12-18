using CommunityToolkit.Mvvm.Input;
using PokemonLikeCsharp.Model;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;

namespace PokemonLikeCsharp.MVVM.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        public ICommand RequestChangeViewCommand { get; set; }
        public ICommand RequestSignInCommand { get; set; }
        public ICommand RequestDatabaseViewCommand { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Database { get; set; }

        private ExercicesMonstersContext _context;

        public LoginViewModel()
        {
            RequestChangeViewCommand = new RelayCommand(HandleRequestChangeViewCommand);
            RequestSignInCommand = new RelayCommand(HandleRequestSignInCommand);
            RequestDatabaseViewCommand = new RelayCommand(HandleRequestDatabaseCommand);
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedPassword = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedPassword);
            }
        }


        public bool ValidateLogin()
        {
            if (_context == null)
            {
                MessageBox.Show("Le contexte de la base de données n'est pas initialisé.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            var user = _context.Logins
                .FirstOrDefault(u => u.Username == Username && u.PasswordHash == HashPassword(Password));

            return user != null;
        }

        public void HandleRequestChangeViewCommand()
        {
            if (ValidateLogin())
            {
                string connectionString = _context.Database.GetConnectionString();
                var playerMonstersWindow = new PlayerMonstersWindow(Username, connectionString);
                playerMonstersWindow.Show();
            }
            else
            {
                MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect.", "Erreur de connexion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void HandleRequestSignInCommand()
        {
            InsertUser(Username, Password);
        }

        public bool InsertUser(string username, string password)
        {
            string hashedPassword = HashPassword(password);
            var existingUser = _context.Logins.FirstOrDefault(u => u.Username == username);
            if (existingUser != null)
            {
                MessageBox.Show("Ce nom d'utilisateur est déjà pris. Veuillez en choisir un autre.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else
            {
                var user = new Login
                {
                    Username = username,
                    PasswordHash = hashedPassword
                };

                _context.Logins.Add(user);
                _context.SaveChanges();
                return true;
            }
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

    }
}
