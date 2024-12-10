using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using PokemonLikeCsharp.Model;

namespace PokemonLikeCsharp.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private readonly ExercicesMonstersContext _context;

        public LoginViewModel()
        {
            _context = new ExercicesMonstersContext();
        }

        // Propriétés
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
            var user = _context.Logins.SingleOrDefault(u => u.Username == Username);
            if (user != null && VerifyPassword(Password, user.PasswordHash))
            {
                // Ouvrir la fenêtre PlayerMonstersWindow et transmettre le nom d'utilisateur
                var playerMonstersWindow = new PlayerMonstersWindow(Username);  // Assurez-vous que Username est passé ici
                playerMonstersWindow.Show();
                Application.Current.MainWindow = playerMonstersWindow;
                Application.Current.Windows.OfType<Window>().FirstOrDefault()?.Close();
            }
            else
            {
                MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect");
            }
        }


        public void Signup()
        {
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

        public void Exit()
        {
            Application.Current.Shutdown();
        }

        // Hachage et vérification du mot de passe
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

        // Implémentation de INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
