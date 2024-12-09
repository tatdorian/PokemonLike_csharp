using System.Linq;
using System.Windows;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using PokemonLikeCsharp.Model;

namespace PokemonLikeCsharp
{
    public partial class PlayerMonstersWindow : Window
    {
        private readonly ExercicesMonstersContext _context;
        private readonly string _username;

        public PlayerMonstersWindow(string username)
        {
            InitializeComponent();
            _context = new ExercicesMonstersContext();

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Utilisateur non connecté", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
                return;
            }

            _username = username;
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
            var addPokemonWindow = new AddPokemonWindow(_username);
            addPokemonWindow.ShowDialog();
            LoadMonsters(); // Recharger la liste après ajout
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
                LoadMonsters(); // Recharger la liste après modification
            }
        }
    }
}
