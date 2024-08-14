using System;
using System.Collections.ObjectModel;
using ArcsUI.Models;
using Avalonia.Controls;
using Avalonia.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ArcsUI.ViewModels;

public partial class ArcsGameViewModel : ViewModelBase
{
    // Game Info
    [ObservableProperty]
    private int _chapter;
    public string ChapterText => $"Chapter {_chapter}";

    [ObservableProperty]
    private int _turn;
    
    // Player Info
    public ArcsPlayerState TestPlayerState = new();
    
    [ObservableProperty]
    private ObservableCollection<ArcsPlayerState> _players;

    [ObservableProperty]
    private ObservableCollection<ActionCard> _localPlayerHand;
    
    [ObservableProperty]
    private ObservableCollection<ActionCard> _roundCards;
    
    public ArcsGameViewModel()
    {
        _chapter = 1;
        _turn = 1;
        Players = new ObservableCollection<ArcsPlayerState>
        {
            new ArcsPlayerState { PlayerName = "Player 1", VictoryPoints = 0 },
            new ArcsPlayerState { PlayerName = "Player 2", VictoryPoints = 0 },
        };
        
        // For testing, generate a random hand for the local player
        _localPlayerHand = new ObservableCollection<ActionCard>();
        for (int i = 0; i < 6; i++)
        {
            int cardValue = new Random().Next(1, 8);
            Suit cardSuit = (Suit)new Random().Next(0, 4);
            _localPlayerHand.Add(new ActionCard( cardValue, cardSuit ));
            Console.WriteLine( $"Dealt card {cardSuit} {cardValue}");
        }
        
        // Cards played this round (initially empty)
        _roundCards = new();

        {
            int cardValue = new Random().Next(1, 8);
            Suit cardSuit = (Suit) new Random().Next(0, 4);
            _roundCards.Add(new ActionCard(cardValue, cardSuit));
        }
    }
    
    private async void OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        Console.WriteLine("DoDrag start");
        if (sender is not Border border)
        {
            Console.WriteLine("Is not border.");
            return;
        }

        if (border.DataContext is not ActionCard card)
        {
            Console.WriteLine("Is not card");
            return;
        }
        
        Console.WriteLine($"Is card {card.Suit} {card.Value}");
    }

}