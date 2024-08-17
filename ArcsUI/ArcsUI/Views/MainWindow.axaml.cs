using System;
using ArcsUI.Controls;
using ArcsUI.Models;
using ArcsUI.ViewModels;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.VisualTree;

namespace ArcsUI.Views;

public partial class MainWindow : Window
{
    private Point _ghostCardPosition = new(0,0);
    private readonly Point _mouseOffset = new(-36,-50);
    //private readonly Point _mouseOffset = new(5,5);
    
    public const string ActionCardFormat = "action-card-format";
    
    public MainWindow()
    {
        InitializeComponent();
        
        AddHandler(DragDrop.DragOverEvent, DragOver);
        AddHandler(DragDrop.DropEvent, Drop);
    }
    
    
    protected override void OnLoaded(RoutedEventArgs e)
    {
        GhostCard.IsVisible = false;
        base.OnLoaded(e);
    }

    private async void OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        Console.WriteLine($"Sender is {sender}");
        if (sender is ActionCardControl cardControl)
        {
            if (cardControl.DataContext is ActionCard card)
            {
                Console.WriteLine($"Drag card {card.Suit} {card.Value}");
                GhostCard.DataContext = card;
                
                var ghostPos = GhostCard.Bounds.Position;
                //var xform = BlargStack.TransformToVisual(MainGrid);
                //var ghostPos2 = ghostPos.Transform(xform.Value);
                var ghostPos2 = ghostPos;
                _ghostCardPosition = new Point(
                    ghostPos2.X - _mouseOffset.X, 
                    ghostPos2.Y - _mouseOffset.Y);
                
                var mousePos = e.GetPosition(MainGrid);
                var offsetX = (mousePos.X - ghostPos2.X) + _mouseOffset.X;
                var offsetY = (mousePos.Y - ghostPos2.Y) + _mouseOffset.Y;
                
                GhostCard.IsVisible = true;
                GhostCard.RenderTransform = new TranslateTransform(offsetX, offsetY);

                Console.WriteLine($"GhostPos {ghostPos} {ghostPos2} mousePos {mousePos} Offset {offsetX}, {offsetY}");

                var dragData = new DataObject();
                dragData.Set( MainWindow.ActionCardFormat, card );
                var result = await DragDrop.DoDragDrop( e, dragData, DragDropEffects.Move );
                Console.WriteLine($"DragAndDrop result: {result}");
                GhostCard.IsVisible = false;
            } 
        }
    }

    private void DragOver(object? sender, DragEventArgs e)
    {
        var currentPosition = e.GetPosition(MainGrid);
        
        var offsetX = currentPosition.X - _ghostCardPosition.X;
        var offsetY = currentPosition.Y - _ghostCardPosition.Y;

        bool wantsDrop = false;
        var sourceControl = e.Source as Control;
        while (sourceControl != null)
        {
            if (sourceControl == PlayedActionCards)
            {
                wantsDrop = true;
                break;
            }
            Console.WriteLine( $"Control: {sourceControl.Name} {sourceControl.GetType()}");
            sourceControl = sourceControl.Parent as Control;
        }
        
        if (!wantsDrop)
        {
            e.DragEffects = DragDropEffects.None;
            var sourceName = (e.Source as Control)?.Name;
            Console.WriteLine($"Drag Over {e.Source} {sourceName} -- {offsetX}, {offsetY}");
        }
        else
        {
            e.DragEffects = DragDropEffects.Move;
            Console.WriteLine($"Over Action Cards {offsetX}, {offsetY}");
        }

        GhostCard.RenderTransform = new TranslateTransform(offsetX, offsetY);
    }

    private void Drop(object? sender, DragEventArgs e)
    {
        Console.WriteLine($"Drop {e}");
        GhostCard.IsVisible = false;
        
        var data = e.Data.Get(MainWindow.ActionCardFormat);
        if (data is not ActionCard card)
        {
            Console.WriteLine("No action card");
            return;
        }
        
        if (DataContext is not ArcsGameViewModel gamevm ) return;
        Console.WriteLine("Dropping action card");
        gamevm.PlayActionCard(card);
    }
}