using System;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;
using PokemonLikeCsharp.Model;
using Microsoft.EntityFrameworkCore;

namespace PokemonLikeCsharp
{
    public partial class BattleWindow : Window
    {
        private Monster _playerMonster;
        private Monster _enemyMonster;
        private Random _random = new Random();
        private readonly ExercicesMonstersContext _context;
        private bool _isPlayerTurn = true;

        public BattleWindow(Monster playerMonster, Monster enemyMonster, ExercicesMonstersContext context)
        {
            InitializeComponent();

            _context = context ?? throw new ArgumentNullException(nameof(context));
            _playerMonster = playerMonster ?? throw new ArgumentNullException(nameof(playerMonster), "Le Pokémon du joueur ne peut pas être nul.");
            _enemyMonster = enemyMonster ?? throw new ArgumentNullException(nameof(enemyMonster), "Le Pokémon ennemi ne peut pas être nul.");

            _context.Entry(_playerMonster).Collection(m => m.Spells).Load();
            _context.Entry(_enemyMonster).Collection(m => m.Spells).Load();

            UpdateUI();
        }

        private void UpdateUI()
        {
            // Mise à jour des informations des monstres
            lblPlayerName.Text = $"{_playerMonster.Name} (HP: {_playerMonster.Health})";
            lblEnemyName.Text = $"{_enemyMonster.Name} (HP: {_enemyMonster.Health})";

            // Récupération des sorts du joueur et association à la ListBox
            var playerSpells = _playerMonster.Spells.Select(ms => new SpellViewModel
            {
                SpellId = ms.Id,
                Name = ms.Name,
                Damage = ms.Damage
            }).ToList();

            // Assurez-vous que ItemsSource est correctement lié
            lstPlayerSpells.ItemsSource = playerSpells;

            // Mise à jour des images des Pokémon
            imgPlayerPokemon.Source = new BitmapImage(new Uri(_playerMonster.ImageUrl, UriKind.RelativeOrAbsolute));
            imgEnemyPokemon.Source = new BitmapImage(new Uri(_enemyMonster.ImageUrl, UriKind.RelativeOrAbsolute));

            // Mise à jour des barres de santé
            pbPlayerHealth.Value = _playerMonster.Health;
            pbEnemyHealth.Value = _enemyMonster.Health;

            // Mise à jour du texte du tour actuel
            TurnIndicator.Text = _isPlayerTurn
                ? $"C'est au tour de {_playerMonster.Name}"
                : $"C'est au tour de {_enemyMonster.Name}";

            // Debugging pour vérifier les sorts
            Console.WriteLine("Player Spells:");
            foreach (var spell in playerSpells)
            {
                Console.WriteLine($"ID: {spell.SpellId}, Name: {spell.Name}, Damage: {spell.Damage}");
            }
        }

        private void lstPlayerSpells_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (lstPlayerSpells.SelectedItem is SpellViewModel selectedSpell)
            {
                var selectedSpellId = selectedSpell.SpellId;
                var selectedSpellName = selectedSpell.Name;
                var selectedSpellDamage = selectedSpell.Damage;

                // Effectuer l'attaque
                _enemyMonster.Health -= selectedSpellDamage;
                MessageBox.Show($"{_playerMonster.Name} utilise {selectedSpellName} et inflige {selectedSpellDamage} dégâts à {_enemyMonster.Name} !");

                if (_enemyMonster.Health <= 0)
                {
                    MessageBox.Show($"{_enemyMonster.Name} a été vaincu !", "Victoire");
                    Close();
                    return;
                }

                // Player turn over, move to enemy turn
                _isPlayerTurn = false;
                EnemyTurn();
            }
        }

        private void EnemyTurn()
        {
            var enemySpell = _enemyMonster.Spells.ElementAt(_random.Next(_enemyMonster.Spells.Count));
            _playerMonster.Health -= enemySpell.Damage;
            MessageBox.Show($"{_enemyMonster.Name} utilise {enemySpell.Name} et inflige {enemySpell.Damage} dégâts à {_playerMonster.Name} !");

            if (_playerMonster.Health <= 0)
            {
                MessageBox.Show($"{_playerMonster.Name} a été vaincu !", "Défaite");
                Close();
            }
            else
            {
                // Enemy turn over, move to player turn
                _isPlayerTurn = true;
                UpdateUI();
            }
        }

        private void RunButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Vous vous êtes enfui !");
            Close();
        }
    }

    public class SpellViewModel
    {
        public int SpellId { get; set; }
        public string Name { get; set; }
        public int Damage { get; set; }
    }
}
