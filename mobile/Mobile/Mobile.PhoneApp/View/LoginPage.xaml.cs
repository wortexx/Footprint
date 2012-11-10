using System.Windows;
using System.Windows.Controls;
using Microsoft.Phone.Controls;
using Mobile.PhoneApp.ViewModel;

namespace Mobile.PhoneApp.View
{
    public partial class LoginPage : BasePage
    {
        private LoginViewModel.LoginPasswordPair loginPasswordPair = new LoginViewModel.LoginPasswordPair();

        public LoginPage()
        {
            InitializeComponent();
            DataContext = ViewModelHolder.Instance.LoginViewModel;

        }

        private void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            CheckEnterButton();
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            CheckEnterButton();
        }

        public LoginViewModel.LoginPasswordPair LoginPasswordPair
        {
            get { return loginPasswordPair; }
        }

        private void CheckEnterButton()
        {
            loginPasswordPair.Login = loginTextBox.Text;
            loginPasswordPair.Password = passwordBox.Password;
            ViewModelHolder.Instance.LoginViewModel.LoginCommand.RaiseCanExecuteChanged();
        }
    }
}