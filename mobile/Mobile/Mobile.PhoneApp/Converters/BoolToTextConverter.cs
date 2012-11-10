using System;
using System.Globalization;
using System.Windows.Data;

namespace Mobile.PhoneApp.Converters
{
    public class BoolToTextConverter: IValueConverter
    {
        public string TrueText { get; set; }
        public string FalseText { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
            {
                if ((bool) value)
                {
                    return TrueText;
                }
                else
                {
                    return FalseText;
                }
            }

            return "Wrong Binding!";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}