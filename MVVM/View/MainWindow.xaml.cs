using System.Windows;
using System.Windows.Controls;
using PokemonLikeCsharp.ViewModel;

namespace PokemonLikeCsharp
{
    public partial class MainWindow : Window
    {
        private readonly LoginViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = DataContext as LoginViewModel;

        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (_viewModel != null && sender is PasswordBox passwordBox)
            {
                _viewModel.Password = passwordBox.Password;
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel?.Login();
        }

        private void SignupButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel?.Signup();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel?.Exit();
        }
    }
}
