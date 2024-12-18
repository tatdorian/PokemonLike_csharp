using System.Windows;
using Microsoft.EntityFrameworkCore;
using PokemonLikeCsharp.Model;
using System.Windows.Input;
using PokemonLikeCsharp.MVVM.View; 



namespace PokemonLikeCsharp
{
    public partial class PlayerMonstersWindow : Window
    {
        private readonly ExercicesMonstersContext _context;
        private readonly string _username;
        private readonly string _connectionString;

        // Modifiez le constructeur pour accepter ces deux arguments
        public PlayerMonstersWindow(string username, string connectionString)
        {
            InitializeComponent();
            _username = username;
            _connectionString = connectionString;
            _context = new ExercicesMonstersContext(_connectionString);

            // Utiliser _connectionString pour initialiser le contexte de la base de données
            _context = new ExercicesMonstersContext(_connectionString);

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Utilisateur non connecté", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
                return;
            }

            LoadMonsters();
        }

        private void LoadMonsters()
        {
            var player = _context.Players.Include(p => p.Monsters).SingleOrDefault(p => p.Name == _username);
            if (player != null)
            {
                lstMonsters.ItemsSource = player.Monsters.ToList();
            }
            else
            {
                MessageBox.Show($"Utilisateur '{_username}' introuvable", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddPokemonBtn_Click(object sender, RoutedEventArgs e)
        {
            var addPokemonWindow = new AddPokemonWindow(_username, _connectionString);
            addPokemonWindow.ShowDialog();
            LoadMonsters();
        }


        private void BackToLogin_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void LstMonsters_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lstMonsters.SelectedItem is Monster selectedMonster)
            {
                var pokemonDetailsWindow = new PokemonDetailsWindow(selectedMonster);
                pokemonDetailsWindow.ShowDialog();
                LoadMonsters();
            }
        }
    }
}