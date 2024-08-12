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
    
    public ActionCard( int value, Suit suit )
    {
        Value = value;
        Suit = suit;
    }
}