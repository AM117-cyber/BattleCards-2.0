using BattleCards.Cards;

namespace BattleCards;
public class Player
{
    public double Health = 1000;
    public List<Card> Graveyard { get; set; }

    public double Mana = 20;
    public string Name { get; set; }
    public List<Card> Deck { get; set; }
    public List<Card> Hand { get; set; }

    public Player(string name, List<Card> deck)
    {
        this.Name = name;
        this.Deck = deck;
        foreach (var card in Deck)
        {
            card.Owner = this;
        }
        Shuffle();

    }
    public void Shuffle ()
    {
        Random r = new Random();
        for (int n = Deck.Count - 1; n > 0; n--)
        {
            int k = r.Next(n + 1);
            Card temp = Deck[n];
            Deck[n] = Deck[k];
            Deck[k] = temp;
        }
    }

    public void Draw(int cant)
    {
        for (int i = 0; i < cant; i++)
        {
            Hand.Add(Deck[0]);
            Deck.Remove(Deck[0]);
        }
    }
    public void RemoveCard(List<Card> HandOrDeck, Card cardToRemove)
    {
        HandOrDeck.Remove(cardToRemove);
    }

    public virtual void ExecuteAction(Game game, int actionExecuterIndex = -1, int actionReceiverIndex = -1, ActionType actionType = ActionType.None)
    {

    }
}

public class HumanPlayer : Player
{
    public HumanPlayer(string name, List<Card> deck) :base(name,deck) { }

    public override void ExecuteAction(Game game, int actionExecuterIndex = -1, int actionReceiverIndex = -1, ActionType actionType = ActionType.None)
    {
        if (actionType != ActionType.None)
        {
            //decirle a game que juegue
        }
    }

}
public class AIPlayer : Player
{

    public AIPlayer(string name, List<Card> deck) : base(name, deck)
    {    
    }

    public override void ExecuteAction(Game game, int actionExecuterIndex = -1, int actionReceiverIndex = -1, ActionType actionType = ActionType.None)
    {
        // decirle a game que juegue
    }
}
