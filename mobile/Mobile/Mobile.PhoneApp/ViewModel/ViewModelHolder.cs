using System.Windows.Navigation;

namespace Mobile.PhoneApp.ViewModel
{
    public class ViewModelHolder
    {
        private static volatile ViewModelHolder instance;
        private static readonly object syncObject = new object();

        private ViewModelHolder()
        {
            MainViewModel = new MainViewModel();
            LoginViewModel = new LoginViewModel();
        }

        public static ViewModelHolder Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncObject)
                    {
                        if (instance == null)
                        {
                            instance = new ViewModelHolder();
                        }
                    }
                }

                return instance;
            }
        }

        public MainViewModel MainViewModel { get; private set; }

        public LoginViewModel LoginViewModel { get; private set; }

        public NavigationService NavigationService { get; set; }
    }
}