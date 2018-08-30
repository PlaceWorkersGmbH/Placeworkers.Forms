using System;
using System.Globalization;
using Xamarin.Forms;

namespace Placeworkers.Forms.Converter
{
    public class BoolNotNullConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => value != null;
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}