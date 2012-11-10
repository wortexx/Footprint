using Mobile.Common.Infrastructure;
using Mobile.PhoneApp.ViewModel;

namespace Mobile.PhoneApp.Commands
{
    public class ChangeTrackingCommand : BaseCommand<MainViewModel>
    {
        public ChangeTrackingCommand(MainViewModel viewModel) : base(viewModel)
        {
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            bool isTrackerRunning = ViewModel.IsTrackerRunning;
            if (isTrackerRunning)
            {
                IsolatedStorageHelper.RemoveValue(IsolatedStorageHelper.IsTrackingRunningKey);
            }
            ViewModel.IsTrackerRunning = !isTrackerRunning;
        }
    }
}