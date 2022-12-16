using BattleCards.Cards;
using System.Runtime.CompilerServices;
using static Utils.Utils;
namespace BattleCards;
public abstract class Player
{
    public PlayerType Type { get; set; }
    public double Health { get; set; }
    //public List<Card> Graveyard { get; set; }
    public List<Card> CardsOnBoard { get; set; }
    public double Mana { get; set; }
    public string Name { get; set; }
    public int Number { get; set; }
    public List<Card> Deck { get; set; }
    public List<Card> Hand { get; set; }

    public Player(string name, List<Card> deck,int number)
    {
        this.Type = PlayerType.Human;
        this.Number = number;
        this.Name = name;
        this.Health = 1000;
        this.Mana = 21;
        this.Deck = deck;
        foreach (var card in Deck)
        {
            card.Owner = this;
        }
        Shuffle();
        this.Hand = new List<Card>();
        this.CardsOnBoard = new List<Card>();
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

    public void InvokeCard(Card card1)
    {
        if (this.Mana >= card1.ManaCost && this.CardsOnBoard.Count < 5)
        {
            this.Mana -= card1.ManaCost;
            this.CardsOnBoard.Add(card1);
            this.Hand.Remove(card1);

        }
    }
    public void Draw(int cant)
    {
        if (this.Mana > 1 && (this.Hand == null ||this.Hand.Count<5))//can turn into a method that checks for every action whether or not it is valid
        {
            for (int i = 0; i < cant; i++)
           {
            Hand.Add(Deck[i]);
            Deck.Remove(Deck[i]);
            this.Mana -= 1;
           }
        }
    }
    public void UpdateSpellsMana()
    {
        foreach (var card in this.CardsOnBoard)
        {
            if (card.Type == CardType.Spell)
            {
                if((card as SpellCard).LifeTime <= 1)
                {
                    CardsOnBoard.Remove(card);
                }
                else
                {
                    (card as SpellCard).LifeTime--;
                }
            }
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
    public HumanPlayer(string name, List<Card> deck, int n) :base(name,deck,n) 
    {
        Type = PlayerType.Human;
    }

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
    
    public AIPlayer(string name, List<Card> deck, int n) : base(name, deck,n)
    {
        Type = PlayerType.GreedyAI;
    }

    public void Play()//pasa por todas las jugadas validas y envia la mejor
    {
        if (Game.CurrentPhase == Phase.MainPhase)
        {
            if (this.Hand.Count < 5 && this.Mana >= 1)
            {

            }
        }
    }
    public override void ExecuteAction(Game game, int actionExecuterIndex = -1, int actionReceiverIndex = -1, ActionType actionType = ActionType.None)
    {
        // decirle a game que juegue
    }
}
