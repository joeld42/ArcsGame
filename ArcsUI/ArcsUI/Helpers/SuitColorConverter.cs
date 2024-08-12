using System;
using System.Globalization;
using ArcsUI.Models;
using Avalonia.Data.Converters;
using Avalonia.Media;

namespace ArcsUI.Helpers;

public class SuitColorConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is Suit suit)
        {
            switch (suit)
            {
                case Suit.Administration:
                    return "#898a82";
                
                case Suit.Aggression:
                    return "#a82024";
                
                case Suit.Construction:
                    return "#d35324";
                
                case Suit.Mobilization:
                    return "#2e899b";
            }
        }

        return "Black";
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}