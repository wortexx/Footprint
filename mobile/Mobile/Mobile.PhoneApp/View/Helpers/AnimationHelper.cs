using System.Windows;
using Microsoft.Phone.Controls;

namespace Mobile.PhoneApp.View.Helpers
{
    public static class AnimationHelper
    {
        public static void AnimateTransition()
        {
            var transition = new TurnstileTransition();
            transition.Mode = TurnstileTransitionMode.BackwardIn;
            PhoneApplicationPage page = (PhoneApplicationPage)((PhoneApplicationFrame)Application.Current.RootVisual).Content;
            ITransition trans = transition.GetTransition(page);
            trans.Completed += delegate { trans.Stop(); };
            trans.Begin();
        }
    }
}