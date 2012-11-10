namespace Mobile.PhoneApp.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        public class LoginPasswordPair
        {
            public string Login { get; private set; }
            public string Password { get; private set; }

            public LoginPasswordPair(string login, string password)
            {
                Login = login;
                Password = password;
            }
        }
    }
}