using ArcsUI.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ArcsUI.ViewModels;

public partial class ArcsPlayerStateViewModel : ViewModelBase
{
    [ObservableProperty]
    private int _victoryPoints;

    [ObservableProperty]
    private string _playerName;
    
    public ArcsPlayerStateViewModel( ArcsPlayerState playerState )
    {
        _victoryPoints = playerState.VictoryPoints;
    }

    public ArcsPlayerState GetPlayerState()
    {
        return new ArcsPlayerState()
        {
            PlayerName = this.PlayerName,
            VictoryPoints = this.VictoryPoints,
        };
    }
}