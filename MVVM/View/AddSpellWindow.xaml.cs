using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
            // Charger tous les sorts depuis la base de données
            var allSpells = _context.Spells.ToList();

            // Filtrer les sorts déjà associés au monstre
            var unassociatedSpells = allSpells
                .Where(spell => !_monster.Spells.Any(ms => ms.Id == spell.Id))
                .ToList();

            // Lier la liste des sorts non associés au ListBox
            SpellsListBox.ItemsSource = unassociatedSpells;
        }
        private void SpellsListBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Récupérer le sort sélectionné
            var selectedSpell = SpellsListBox.SelectedItem as Spell;

            if (selectedSpell == null)
                return;

            // Vérifier que le sort n'est pas déjà ajouté au monstre
            if (_monster.Spells.Any(spell => spell.Id == selectedSpell.Id))
            {
                MessageBox.Show("Ce sort est déjà ajouté au monstre.", "Sort déjà présent", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            // Vérifier que le monstre n'a pas déjà 4 sorts
            if (_monster.Spells.Count >= 4)
            {
                MessageBox.Show("Le monstre ne peut avoir que 4 sorts maximum.", "Limite atteinte", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Récupérer le monstre depuis la base de données avec les sorts associés
            var monster = _context.Monsters
                .Include(m => m.Spells)
                .FirstOrDefault(m => m.Id == _monster.Id);

            if (monster == null)
            {
                MessageBox.Show("Aucun monstre trouvé avec cet ID.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Ajouter le sort au monstre
            monster.Spells.Add(selectedSpell);

            // Enregistrer les changements dans la base de données
            _context.SaveChanges();

            MessageBox.Show("Sort ajouté avec succès au monstre.", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);

            DialogResult = true;
            Close();
        }






        private void Close_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
