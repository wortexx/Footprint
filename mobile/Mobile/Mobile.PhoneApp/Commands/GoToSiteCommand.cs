using System;
using Microsoft.Phone.Tasks;
using Mobile.PhoneApp.ViewModel;

namespace Mobile.PhoneApp.Commands
{
    public class GoToSiteCommand : BaseCommand<MainViewModel>
    {
        public GoToSiteCommand(MainViewModel viewModel)
            : base(viewModel)
        {
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            WebBrowserTask wbTask = new WebBrowserTask
                                        {
                                            Uri = new Uri("http://footprint.azurewebsites.net", UriKind.Absolute)
                                        };
            wbTask.Show();
        }
    }
}