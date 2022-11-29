using BattleCards.Cards;

namespace BattleCards;
public class Player
{
    public double Health { get; set; }
    public int Number { get; private set; }
    public List<Card> Graveyard;

    public double Mana { get; set; }
    public string Name;
    private int NumberForTurnOrder = 0;

    public List<Card> Deck;
    public List<Card> Hand;
    public bool Winner = false;

    public Player(string name)
    {
        this.Name = name;

    }

    public void GeneratePersonalizedDeck(Card card)
    {
        if (Deck.Count == 50)
        {
            throw new ArgumentException("The deck already reached the maximum of cards.If you want to include this card you must remove another one.");
        }// considerar si preguntar o no: "terminaste con el deck?";
        else
        {
            Deck.Add(card);
        }

    }

    public void RemoveCard(List<Card> HandOrDeck, Card cardToRemove)
    {
        HandOrDeck.Remove(cardToRemove);
    }

    /*public void TakeCard(){
        Hand.Add();
    }*/

}

public class VirtualPlayerSeamus : Player
{
    public VirtualPlayerSeamus(string name) : base(name)
    {
        
    }
}
public class VirtualPlayerDean : Player
{
    public VirtualPlayerDean(string name) : base(name)
    {

    }
}
