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
            imgPokemon.Source = new BitmapImage(new Uri(_monster.ImageUrl));
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
    }
}
