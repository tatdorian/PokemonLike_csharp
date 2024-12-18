using Microsoft.Win32;
using System;
using System.Linq;
using System.Windows;
using PokemonLikeCsharp.Model;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace PokemonLikeCsharp
{
    public partial class AddPokemonWindow : Window
    {
        private readonly ExercicesMonstersContext _context;
        private readonly string _username;

        // Constructeur qui accepte un paramètre "username"
        public AddPokemonWindow(string username, string databaseLink)
        {
            InitializeComponent();
            _context = new ExercicesMonstersContext(databaseLink);

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Utilisateur non connecté", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
                return;
            }

            _username = username;
        }



        private void AddPokemon_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPokemonName.Text) || string.IsNullOrEmpty(txtPokemonHealth.Text))
            {
                MessageBox.Show("Veuillez remplir tous les champs", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!int.TryParse(txtPokemonHealth.Text, out int health))
            {
                MessageBox.Show("La valeur de santé doit être un nombre", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(txtImageUrl.Text))
            {
                MessageBox.Show("Veuillez entrer une URL d'image valide", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var player = _context.Players.SingleOrDefault(p => p.Name == _username);
            if (player == null)
            {
                MessageBox.Show($"Utilisateur '{_username}' introuvable", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var newMonster = new Monster
            {
                Name = txtPokemonName.Text,
                Health = health,
                ImageUrl = txtImageUrl.Text 
            };

            player.Monsters.Add(newMonster);
            _context.SaveChanges();
            this.Close();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void txtImageUrl_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Récupérer l'URL de l'image à partir du TextBox
            string imageUrl = txtImageUrl.Text.Trim();

            if (!string.IsNullOrEmpty(imageUrl))
            {
                try
                {
                    // Créer un objet Uri à partir de l'URL de l'image
                    Uri imageUri = new Uri(imageUrl, UriKind.Absolute);

                    // Charger l'image dans le contrôle Image
                    imgPokemon.Source = new BitmapImage(imageUri);
                }
                catch (Exception ex)
                {
                    // En cas d'erreur (par exemple URL invalide)
                    imgPokemon.Source = null;
                    MessageBox.Show($"Erreur lors du chargement de l'image : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                // Si l'URL est vide, cacher l'image
                imgPokemon.Source = null;
            }
        }
    }
}
