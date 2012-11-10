using System;
using Microsoft.Phone.Scheduler;
using Mobile.Common;
using Mobile.Common.Infrastructure;
using Mobile.PhoneApp.Commands;

namespace Mobile.PhoneApp.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private const string FootprintTaskName = "FootprintTask";

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
                if (value)
                {
                    CreateResourceTask();
                }
                else
                {
                    RemoveResourceTask();
                }
                OnPropertyChanged("IsTrackerRunning");
            }
        }

        private static void CreateResourceTask()
        {
            var resourceTask = new ResourceIntensiveTask(FootprintTaskName);

            resourceTask.Description = "Footprint task";
            resourceTask.ExpirationTime = DateTime.Now.AddDays(1);

            // If the agent is already registered with the system,
            RemoveResourceTask();

            //not supported in current version
            //periodicTask.BeginTime = DateTime.Now.AddSeconds(10);

            //only can be called when application is running in foreground
            ScheduledActionService.Add(resourceTask);
        }

        private static void RemoveResourceTask()
        {
            if (ScheduledActionService.Find(FootprintTaskName) != null)
            {
                ScheduledActionService.Remove(FootprintTaskName);
            }
        }
    }
}