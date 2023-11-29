using System;
using System.Globalization;
using System.Windows.Data;

namespace CustomReminderExample {
    public class TimeSpanToNumberConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return ((TimeSpan)value).Minutes;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return TimeSpan.FromMinutes(System.Convert.ToDouble(value));
        }
    }
}
