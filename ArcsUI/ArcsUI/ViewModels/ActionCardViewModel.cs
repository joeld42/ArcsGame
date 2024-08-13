using ArcsUI.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ArcsUI.ViewModels;

public partial class ActionCardViewModel : ViewModelBase
{
    [ObservableProperty] private int _value;

    //[ObservableProperty]
    //private string _playerName;
    private Suit _suit;
    public ActionCardViewModel( ActionCard card )
    {
        _value = card.Value;
    }

    public ActionCard GetCard()
    {
        return new ActionCard(this.Value, _suit);
    }
}