using System;
using System.Windows;
using PokemonLikeCsharp.Model;

namespace PokemonLikeCsharp
{
    public partial class EditPokemonWindow : Window
    {
        private readonly Monster _monster;
        private readonly ExercicesMonstersContext _context;

        public EditPokemonWindow(Monster monster)
        {
            InitializeComponent();
            _monster = monster;
            _context = new ExercicesMonstersContext();
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
                _monster.ImageUrl = txtImageUrl.Text;

                // Attach the entity to the context and mark it as modified
                _context.Monsters.Attach(_monster);
                _context.Entry(_monster).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                _context.SaveChanges();

                MessageBox.Show("Pokémon modifié avec succès", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
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
