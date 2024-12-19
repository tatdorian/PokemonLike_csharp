using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using PokemonLikeCsharp.Model;

namespace PokemonLikeCsharp
{
    public partial class SelectedPokemonWindow : Window
    {
        private readonly ExercicesMonstersContext _context;
        private readonly Monster _playerMonster; 
        private readonly string _username;

        public SelectedPokemonWindow(Monster playerMonster, string username, string connectionString)
        {
            InitializeComponent();

           
            _playerMonster = playerMonster ?? throw new ArgumentNullException(nameof(playerMonster), "Le Pokémon du joueur ne peut pas être nul.");
            _username = username;
            _context = new ExercicesMonstersContext(connectionString);

            if (string.IsNullOrEmpty(_username))
            {
                MessageBox.Show("Utilisateur non connecté", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                Close();
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
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PokemonList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lstMonsters.SelectedItem is Monster selectedMonster)
            {
                // Passez le contexte (_context) à BattleWindow
                var battlePokemon = new BattleWindow(_playerMonster, selectedMonster, _context);
                battlePokemon.ShowDialog();
                LoadMonsters();
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un Pokémon valide pour le combat.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
