using System;
using System.Globalization;
using System.Windows.Data;

namespace Cashbox.ViewModels
{
    internal class DecimalToPercentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var x = (decimal)value;
            return Math.Round(x * 100) + "%";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
