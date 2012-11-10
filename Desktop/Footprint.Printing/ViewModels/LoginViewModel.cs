using System.Linq;
using Caliburn.Micro;
using Footprint.Printing.Framework;
using Footprint.Printing.Services;
using Footprint.Printing.Services.Auth;

namespace Footprint.Printing.ViewModels
{
    public class LoginViewModel : Screen, IShell
    {
        private readonly IAuthService _authService;
        private string _userName;
        private string _password;
        private string _errors;

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; 
                NotifyOfPropertyChange(() => this.UserName);
                NotifyOfPropertyChange(() => this.CanLogin);
            }
        }

        public string Errors
        {
            get { return _errors; }
            set
            {
                _errors = value;
                NotifyOfPropertyChange(() => this.Errors);
            }
        }

        public string Password
        {
            get { return _password; }
            set { 
                _password = value; 
                NotifyOfPropertyChange(() => this.Password);                
            }
        }

        public LoginViewModel(IAuthService authService)
        {
            _authService = authService;
        }

        public bool CanLogin
        {
            get { return !string.IsNullOrEmpty(this.UserName); }
        }

        public void Login()
        {
            var results = _authService.Login(this.UserName, this.Password);
            if (results.Any())
            {
                this.Errors = string.Join(", ", results);
                return;
            }

            ShowWorkScreen();
        }

        private void ShowWorkScreen()
        {
            MainWindow.UserName = this.UserName;
            MainWindow.ShowPrinting();
        }

        private IMainWindow MainWindow
        {
            get { return ((IMainWindow)this.Parent); }
        }
    }
}