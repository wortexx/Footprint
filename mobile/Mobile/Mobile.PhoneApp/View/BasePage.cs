using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Mobile.PhoneApp.View.Helpers;

namespace Mobile.PhoneApp.View
{
    public class BasePage : PhoneApplicationPage
    {
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            if (this is LoginPage)
            {
                NavigationService.RemoveBackEntry();
            }
//            BasePage content = e.Content as BasePage;
//            if (content != null)
//            {
//                PageNavigator.Instance.ChangeViewModel(content.DataContext);
//            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            AnimationHelper.AnimateTransition();
        }
    }
}