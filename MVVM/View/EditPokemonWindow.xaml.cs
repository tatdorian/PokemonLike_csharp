using System;
using System.Windows;
using PokemonLikeCsharp.Model;

namespace PokemonLikeCsharp
{
    public partial class EditPokemonWindow : Window
    {
        private readonly Monster _monster;
        private readonly ExercicesMonstersContext _context;

        public EditPokemonWindow(Monster monster, string databaseLink)
        {
            InitializeComponent();
            _monster = monster;
            _context = new ExercicesMonstersContext(databaseLink);  
            LoadMonsterDetails();
        }

        private void LoadMonsterDetails()
        {
            txtName.Text = _monster.Name;
            txtHealth.Text = _monster.Health.ToString();
            txtImageUrl.Text = _monster.ImageUrl;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _monster.Name = txtName.Text;

                if (int.TryParse(txtHealth.Text, out int health))
                {
                    _monster.Health = health;
                }
                else
                {
                    MessageBox.Show("Veuillez entrer une valeur numérique valide pour la santé.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (!string.IsNullOrEmpty(txtImageUrl.Text))
                {
                    try
                    {
                        var uri = new Uri(txtImageUrl.Text);
                        _monster.ImageUrl = txtImageUrl.Text;
                    }
                    catch (UriFormatException)
                    {
                        MessageBox.Show("L'URL de l'image est invalide. Veuillez entrer une URL valide.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("L'URL de l'image ne peut pas être vide.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                _context.Monsters.Attach(_monster);
                _context.Entry(_monster).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                _context.SaveChanges();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur s'est produite : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                Console.WriteLine(ex);
            }
        }
    }
}
