using System;
using ArcsUI.Controls;
using ArcsUI.Models;
using Avalonia.Controls;
using Avalonia.Input;

namespace ArcsUI.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        
        AddHandler(DragDrop.DragOverEvent, DragOver);
        AddHandler(DragDrop.DropEvent, Drop);
    }

    private async void OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        Console.WriteLine($"Sender is {sender}");
        if (sender is ActionCardControl cardControl)
        {
            if (cardControl.DataContext is ActionCard card)
            {
                Console.WriteLine($"Drag card {card.Suit} {card.Value}");  
            } 
        }
    }

    private void DragOver(object? sender, DragEventArgs e)
    {
        Console.WriteLine($"Drag Over {e}");
    }

    private void Drop(object? sender, DragEventArgs e)
    {
        Console.WriteLine($"Drop {e}");
    }
}