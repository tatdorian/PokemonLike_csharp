using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media.Imaging;
using PokemonLikeCsharp.Model;
using System.Linq;
using System.Windows.Controls;

namespace PokemonLikeCsharp
{
    public partial class PokemonDetailsWindow : Window
    {
        private readonly Monster _monster;

        // Constructeur qui accepte un objet Monster
        public PokemonDetailsWindow(Monster monster)
        {
            InitializeComponent();
            _monster = monster;  // Assurez-vous de l'assigner à la variable privée
            LoadMonsterDetails();  // Charge les détails du monstre
        }

        private void LoadMonsterDetails()
        {
            // Remplir l'interface avec les détails du monstre
            txtName.Text = _monster.Name;
            txtHealth.Text = _monster.Health.ToString();

            if (!string.IsNullOrEmpty(_monster.ImageUrl))
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
                imgPokemon.Source = null;
            }
        }


        private void EditPokemonBtn_Click(object sender, RoutedEventArgs e)
        {
            string databaseLink = App.ConnectionString;
            var editWindow = new EditPokemonWindow(_monster, databaseLink);
            editWindow.ShowDialog();
            LoadMonsterDetails();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddSpellsBtn_Click(object sender, RoutedEventArgs e)
        {
            var addSpellWindow = new AddSpellWindow(_monster, App.ConnectionString);

            if (addSpellWindow.ShowDialog() == true)
            {
                foreach (var spell in addSpellWindow.Spells)
                {
                    _monster.Spells.Add(spell);
                }
                LoadMonsterDetails();
            }
        }

    }
}