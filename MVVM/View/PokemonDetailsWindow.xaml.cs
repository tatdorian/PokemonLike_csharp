using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media.Imaging;
using PokemonLikeCsharp.Model;
using System.Linq;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore.Update.Internal;
using Microsoft.EntityFrameworkCore;

namespace PokemonLikeCsharp
{
    public partial class PokemonDetailsWindow : Window
    {
        private readonly Monster _monster;
         private readonly string _username;


        public PokemonDetailsWindow(Monster monster, string username)
        {
            InitializeComponent();
            _monster = monster;
            _username = username;
            LoadMonsterDetails();  
        }
        private void LoadMonsterDetails()
        {
           
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

        private void SelectedPokemonBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Assurez-vous de récupérer la chaîne de connexion correctement
                string connectionString = App.ConnectionString; // Vous pouvez récupérer la chaîne de connexion via App.ConnectionString ou en la passant par ailleurs

                string username = _username; 
                var selectedPokemonWindow = new SelectedPokemonWindow(_monster, username, connectionString);

                selectedPokemonWindow.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'ouverture du combat : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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