using System;
using System.Collections;
using System.Globalization;
using Avalonia.Data.Converters;
using Avalonia.Controls;

public class EmptyListVisibilityConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is IList list && list.Count == 0)
        {
            return Avalonia.Controls.Visibility.Visible;
        }
        return Avalonia.Controls.Visibility.Collapsed;
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}