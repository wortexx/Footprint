using Microsoft.Phone.Controls;
using Mobile.PhoneApp.ViewModel;

namespace Mobile.PhoneApp.View
{
    public partial class MainPage : BasePage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            DataContext = ViewModelHolder.Instance.MainViewModel;
        }
    }
}