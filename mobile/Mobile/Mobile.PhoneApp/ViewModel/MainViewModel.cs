using Mobile.Common;
using Mobile.Common.Infrastructure;
using Mobile.PhoneApp.Commands;

namespace Mobile.PhoneApp.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            isTrackerRunning = IsolatedStorageHelper.GetValue<bool>(IsolatedStorageHelper.IsTrackingRunningKey);

            InitializeCommands();
        }

        private void InitializeCommands()
        {
            ChangeTrackingCommand = new ChangeTrackingCommand(this);
            GoToSiteCommand = new GoToSiteCommand(this);
        }

        public ChangeTrackingCommand ChangeTrackingCommand { get; private set; }
        public GoToSiteCommand GoToSiteCommand { get; private set; }

        private bool isTrackerRunning;
        public bool IsTrackerRunning
        {
            get { return isTrackerRunning; }
            set
            {
                if (isTrackerRunning == value)
                {
                    return;
                }
                IsolatedStorageHelper.SetValue(IsolatedStorageHelper.IsTrackingRunningKey, value);
                isTrackerRunning = value;
                OnPropertyChanged("IsTrackerRunning");
            }
        }
    }
}