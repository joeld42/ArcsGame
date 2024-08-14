using ArcsUI.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ArcsUI.ViewModels;

public partial class ActionCardViewModel : ViewModelBase
{
    [ObservableProperty] 
    private int _value;

    [ObservableProperty]
    private Suit _suit;

    ActionCardViewModel()
    {
        _value = 3;
        _suit = Suit.Construction;
    }
    
    public ActionCardViewModel( ActionCard card )
    {
        _value = card.Value;
    }

    public ActionCard GetCard()
    {
        return new ActionCard(this.Value, _suit);
    }
}