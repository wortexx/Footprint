using System;
using System.Text.RegularExpressions;
using System.Windows;
using Mobile.Common.Infrastructure;
using Mobile.Common.Model;
using Mobile.PhoneApp.ViewModel;
using RestSharp;

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
                var loginPasswordPair = parameter as LoginViewModel.LoginPasswordPair;
                if (loginPasswordPair != null)
                {
                    Login(loginPasswordPair);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        private void Login(LoginViewModel.LoginPasswordPair loginPasswordPair)
        {
            RestClient restClient = WebApi.GetClient();
            var request = new RestRequest("api/user/login?email={email}&password={password}", Method.GET);
            request.AddUrlSegment("email", loginPasswordPair.Login); 
            request.AddUrlSegment("password", loginPasswordPair.Password);
            restClient.ExecuteAsync<LoginResponseModel>(request, OnLoginSuccess);
        }

        private void OnLoginSuccess(IRestResponse<LoginResponseModel> response)
        {
            try
            {
                if (response.ErrorException == null)
                {
                    string token = response.Data.Token;
                    if (string.IsNullOrWhiteSpace(token))
                    {
                        MessageBox.Show("User or password are incorrect.");
                    }
                    IsolatedStorageHelper.SetValue(IsolatedStorageHelper.AuthenticationTokenKey, token);
                    ViewModelHolder.Instance.NavigationService.Navigate(new Uri(@"/View/MainPage.xaml", UriKind.Relative));
                    ViewModelHolder.Instance.NavigationService.RemoveBackEntry();
                }
            }
            finally
            {
                ViewModel.IsTryingToLogin = false;
            }
        }
    }
}