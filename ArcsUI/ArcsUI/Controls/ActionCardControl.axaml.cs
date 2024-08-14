using System;
using ArcsUI.Models;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;

namespace ArcsUI.Controls;

public partial class ActionCardControl : UserControl
{
    public ActionCardControl()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    // private async void OnPointerPressed(object? sender, PointerPressedEventArgs e)
    // {
    //     Console.WriteLine("DoDrag start");
    //     if (sender is not Border border)
    //     {
    //         Console.WriteLine("Is not border.");
    //         return;
    //     }
    //
    //     if (border.DataContext is not ActionCard card)
    //     {
    //         Console.WriteLine("Is not card");
    //         return;
    //     }
    //     
    //     Console.WriteLine($"Is card {card.Suit} {card.Value}");
    // }
}