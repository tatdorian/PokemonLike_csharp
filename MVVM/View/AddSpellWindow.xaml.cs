using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using PokemonLikeCsharp.Model;

namespace PokemonLikeCsharp
{
    public partial class AddSpellWindow : Window
    {
        public List<Spell> Spells { get; private set; } = new List<Spell>();

        private readonly Monster _monster;
        private readonly ExercicesMonstersContext _context;

        public AddSpellWindow(Monster monster, string databaseLink)
        {
            InitializeComponent();
            _context = new ExercicesMonstersContext(databaseLink);
            _monster = monster;

            LoadAvailableSpells();
        }

        private void LoadAvailableSpells()
        {
            var allSpells = _context.Spells.ToList();

            var unassociatedSpells = allSpells
                .Where(spell => !_monster.Spells.Any(ms => ms.Id == spell.Id))
                .ToList();

            SpellsListBox.ItemsSource = unassociatedSpells;
        }

        private void SpellsListBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var selectedSpell = SpellsListBox.SelectedItem as Spell;

            if (selectedSpell == null)
                return;

            if (_monster.Spells.Any(spell => spell.Id == selectedSpell.Id))
            {
                MessageBox.Show("Ce sort est déjà ajouté au monstre.", "Sort déjà présent", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (_monster.Spells.Count >= 4)
            {
                MessageBox.Show("Le monstre ne peut avoir que 4 sorts maximum.", "Limite atteinte", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var monster = _context.Monsters
                .Include(m => m.Spells)
                .FirstOrDefault(m => m.Id == _monster.Id);

            if (monster == null)
            {
                MessageBox.Show("Aucun monstre trouvé avec cet ID.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            monster.Spells.Add(selectedSpell);

            _context.SaveChanges();

            MessageBox.Show("Sort ajouté avec succès au monstre.", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);

            DialogResult = true;
            Close();
        }

        private void SpellsListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var selectedSpell = SpellsListBox.SelectedItem as Spell;

            if (selectedSpell != null)
            {
                SpellDescriptionTextBlock.Text = selectedSpell.Description;
                SpellDamageTextBlock.Text = selectedSpell.Damage.ToString();
            }
            else
            {
                SpellDescriptionTextBlock.Text = "Sélectionnez un sort pour voir la description";
                SpellDamageTextBlock.Text = "Sélectionnez un sort pour voir les dégâts";
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
