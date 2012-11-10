using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Mobile.PhoneApp.Converters
{
    public class BooleanToVisibilityConverter: IValueConverter
    {
        public bool IsInverted { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
            {
                var b = (bool) value;
                if (IsInverted)
                {
                    b = !b;
                }
                return GetVisibility(b);
            }
            return Visibility.Collapsed;
        }

        private Visibility GetVisibility(bool value)
        {
            if (value)
            {
                return Visibility.Visible;
            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}