using Mobile.Common.Infrastructure;
using Mobile.PhoneApp.Commands;

namespace Mobile.PhoneApp.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        public LoginViewModel()
        {
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            LoginCommand = new LoginCommand(this);
        }

        public LoginCommand LoginCommand { get; set; }

        private bool isTryingToLogin;
        public bool IsTryingToLogin
        {
            get { return isTryingToLogin; }
            set
            {
                if (isTryingToLogin == value)
                {
                    return;
                }

                isTryingToLogin = value;
                OnPropertyChanged("IsTryingToLogin");
            }
        }

        public bool IsLoginned
        {
            get
            {
                var token = IsolatedStorageHelper.GetValue<string>(IsolatedStorageHelper.AuthenticationTokenKey);
                return !string.IsNullOrWhiteSpace(token);
            }
        }

        public class LoginPasswordPair
        {
            public string Login { get; set; }
            public string Password { get; set; }
        }
    }
}