using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Microsoft.EntityFrameworkCore;
using PokemonLikeCsharp.Model;
using PokemonLikeCsharp.Models;

namespace PokemonLikeCsharp
{
    public partial class PokemonDetailsWindow : Window
    {
        private readonly Monster _monster;

        public PokemonDetailsWindow(Monster monster)
        {
            InitializeComponent();
            _monster = monster;
            LoadMonsterDetails();
        }

        private void LoadMonsterDetails()
        {
            using (var context = new PokemonDbContext())
            {
                var monsterWithSpells = context.Monsters
                                                .Include(m => m.MonsterSpells)
                                                .ThenInclude(ms => ms.Spell)
                                                .FirstOrDefault(m => m.Id == _monster.Id);

                if (monsterWithSpells != null)
                {
                    _monster.MonsterSpells = monsterWithSpells.MonsterSpells;
                }
            }

            // Update monster basic information
            txtName.Text = _monster.Name;
            txtHealth.Text = _monster.Health.ToString();

            if (!string.IsNullOrEmpty(_monster.ImageUrl))
            {
                if (Uri.IsWellFormedUriString(_monster.ImageUrl, UriKind.Absolute) &&
                    (_monster.ImageUrl.StartsWith("http://") || _monster.ImageUrl.StartsWith("https://")))
                {
                    try
                    {
                        imgPokemon.Source = new BitmapImage(new Uri(_monster.ImageUrl));
                    }
                    catch (UriFormatException)
                    {
                        MessageBox.Show("L'URL de l'image est invalide.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                        imgPokemon.Source = null;
                    }
                }
                else
                {
                    MessageBox.Show("L'URL de l'image est invalide.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    imgPokemon.Source = null;
                }
            }
            else
            {
                imgPokemon.Source = null;
            }

            // Refresh spells display
            SpellsStackPanel.Children.Clear(); // Clear previous spells

            // Add all current spells of the monster
            foreach (var monsterSpell in _monster.MonsterSpells)
            {
                var spell = monsterSpell.Spell;
                var spellTextBlock = new TextBlock
                {
                    Text = $"{spell.Name}: {spell.Description} (Dégâts: {spell.Damage})",
                    Margin = new Thickness(0, 5, 0, 5),
                    FontSize = 14
                };
                SpellsStackPanel.Children.Add(spellTextBlock);
            }
        }

        private void EditPokemonBtn_Click(object sender, RoutedEventArgs e)
        {
            var editWindow = new EditPokemonWindow(_monster);
            editWindow.ShowDialog();
            LoadMonsterDetails();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddSpellsBtn_Click(object sender, RoutedEventArgs e)
        {
            var addSpellWindow = new AddSpellWindow(_monster);
            if (addSpellWindow.ShowDialog() == true)
            {
                foreach (var spell in addSpellWindow.Spells)
                {
                    _monster.MonsterSpells.Add(new MonsterSpell { MonsterId = _monster.Id, SpellId = spell.Id, Spell = spell });
                }
                LoadMonsterDetails();
            }
        }
    }
}
