using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Navigation;
using Mobile.Common.Infrastructure;
using Mobile.PhoneApp.ViewModel;

namespace Mobile.PhoneApp.Commands
{
    public class LoginCommand : BaseCommand<LoginViewModel>
    {
        public LoginCommand(LoginViewModel viewModel) : base(viewModel)
        {
        }

        public override bool CanExecute(object parameter)
        {
            var loginPasswordPair = parameter as LoginViewModel.LoginPasswordPair;
            if (loginPasswordPair != null)
            {
                return CheckLogin(loginPasswordPair.Login) && CheckPassword(loginPasswordPair.Password);
            }

            return false;
        }

        private bool CheckPassword(string password)
        {
            return !string.IsNullOrWhiteSpace(password);
        }

        private static bool CheckLogin(string login)
        {
            if (string.IsNullOrWhiteSpace(login))
            {
                return false;
            }

            return new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,6}$").IsMatch(login);
        }

        public override void Execute(object parameter)
        {
            ViewModel.IsTryingToLogin = true;
            try
            {
                Thread.Sleep(5000);
                var loginPasswordPair = parameter as LoginViewModel.LoginPasswordPair;
                if (loginPasswordPair != null)
                {
                    IsolatedStorageHelper.SetValue(IsolatedStorageHelper.AuthenticationTokenKey, Login(loginPasswordPair));
                    ViewModelHolder.Instance.NavigationService.Navigate(new Uri(@"/View/MainPage.xaml", UriKind.Relative));
                    ViewModelHolder.Instance.NavigationService.RemoveBackEntry();
                }
            }
            catch (Exception e)
            {
                ViewModel.IsTryingToLogin = false;
                MessageBox.Show(e.Message);
            }

        }

        private string Login(LoginViewModel.LoginPasswordPair loginPasswordPair)
        {
            return "Chuck Norris Token";
        }
    }
}