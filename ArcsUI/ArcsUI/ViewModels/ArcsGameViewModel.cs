using System;
using System.Collections.ObjectModel;
using ArcsUI.Models;
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
        }
    }

}