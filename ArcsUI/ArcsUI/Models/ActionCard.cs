namespace ArcsUI.Models;

public enum Suit
{
    Administration,
    Aggression,
    Construction,
    Mobilization
}

public class ActionCard
{
    public int Value { get; }
    public Suit Suit { get; }
    
    public bool ShowPip1 {
        get => Value < 5;
    }

    
    public bool ShowPip2 {
        get => Value < 7;
    }
    
    public bool ShowPip3 {
        get => true;
    }

    public bool ShowPip4 {
        get => Value < 3;
    }

    
    public ActionCard( int value, Suit suit )
    {
        Value = value;
        Suit = suit;
    }
}