
using System.Windows;
using PokemonLikeCsharp.Model;

namespace PokemonLikeCsharp
{
    public partial class MainWindow : Window
    {
        private readonly ExercicesMonstersContext _context;

        public MainWindow()
        {
            InitializeComponent();
            _context = new ExercicesMonstersContext();
        }

        // Logique pour le bouton de connexion
        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            var user = _context.Logins.SingleOrDefault(u => u.Username == username);
            if (user != null && user.VerifyPassword(password))
            {

                var playerMonstersWindow = new PlayerMonstersWindow(username);
                Application.Current.MainWindow = playerMonstersWindow;
                playerMonstersWindow.Show();
                this.Close();

            }
            else
            {
                MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect");
            }
        }


        private void signupBtn_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            if (_context.Logins.Any(u => u.Username == username))
            {
                MessageBox.Show("Nom d'utilisateur déjà pris");
                return;
            }

            var newUser = new Login { Username = username };
            newUser.SetPassword(password);
            _context.Logins.Add(newUser);
            _context.SaveChanges();

            var newPlayer = new Player { Name = username, LoginId = newUser.Id };
            _context.Players.Add(newPlayer);
            _context.SaveChanges();

            MessageBox.Show("Compte créé avec succès !");
        }

        // Logique pour quitter l'application
        private void exitApp(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
