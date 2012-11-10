namespace Mobile.PhoneApp.ViewModel
{
    public class ViewModelHolder
    {
        private static volatile ViewModelHolder instance;
        private static readonly object syncObject = new object();

        private ViewModelHolder()
        {
            MainViewModel = new MainViewModel();
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
    }
}