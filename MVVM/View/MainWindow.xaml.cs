using System.Windows;
using System.Windows.Controls;
using PokemonLikeCsharp.MVVM.ViewModel;

namespace PokemonLikeCsharp.MVVM.View
{
    public partial class MainWindow : Window
    {
        private readonly LoginViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent(); 
            _viewModel = new LoginViewModel();
            DataContext = _viewModel; 
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is LoginViewModel viewModel)
            {
                viewModel.Password = ((PasswordBox)sender).Password;
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
