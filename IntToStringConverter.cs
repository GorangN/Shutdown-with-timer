namespace Shutdown_with_timer
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;

    public class IntToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value?.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var str = value as string;
            if (int.TryParse(str, out int result))
                return result;

            return DependencyProperty.UnsetValue; // verhindert Binding-Fehler
        }
    }
}
