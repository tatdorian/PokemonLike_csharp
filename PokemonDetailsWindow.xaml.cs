using System;
using System.Windows;
using System.Windows.Media.Imaging;
using PokemonLikeCsharp.Model;

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
                        imgPokemon.Source = null; // Ou définir une image par défaut
                    }
                }
                else
                {
                    MessageBox.Show("L'URL de l'image est invalide.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    imgPokemon.Source = null; // Ou définir une image par défaut
                }
            }
            else
            {
                imgPokemon.Source = null; // Ou définir une image par défaut
            }
        }

        private void EditPokemonBtn_Click(object sender, RoutedEventArgs e)
        {
            var editWindow = new EditPokemonWindow(_monster);
            editWindow.ShowDialog();
            LoadMonsterDetails(); // Recharger les détails du monstre après la fermeture de la fenêtre d'édition
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
