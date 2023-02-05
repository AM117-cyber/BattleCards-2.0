using BattleCardsLibrary.Utils;
namespace BattleCardsLibrary.PlayerNamespace;



public class Player
{
    
    public double Health { get; set; }
    //public List<Card> Graveyard { get; set; }
    public List<ICard> CardsOnBoard { get; }
    public double Mana { get; set; }
    public string Name { get; }
    public int Number { get; set; }
    public List<ICard> Deck { get;  }
    public List<ICard> Hand { get; }

    public Player(string name, List<ICard> deck, int number)
    {
        
        Number = number;
        Name = name;
        Health = 1000;
        Mana = number == 1 ? 20 : 25;
        Deck = deck;
        foreach (var card in Deck)
        {
            card.Owner = this;
        }
        Shuffle();
        Hand = new List<ICard>();
        CardsOnBoard = new List<ICard>();
    }
    
    public void FinishTurn()
    {
        this.MarkCardsAsUnused();
        this.Mana = (this.Mana + 5) < 20 ? this.Mana + 5 : this.Mana = 20;
    }
    
    public bool NoMonstersOnBoard()
    {
        foreach (var card in this.CardsOnBoard)
        {
            if (card.Type == CardType.Monster)
            {
                return false;
            }
        }
        return true;
    }
    public void MarkCardsAsUnused()
    {
        foreach (var card in CardsOnBoard)
        {
            card.SetUsed(false);
        }
    }
    public void Shuffle()
    {
        Random r = new Random();
        for (int n = Deck.Count - 1; n > 0; n--)
        {
            int k = r.Next(n + 1);
            ICard temp = Deck[n];
            Deck[n] = Deck[k];
            Deck[k] = temp;
        }
    }

    public void InvokeCard(ICard card1)
    {
        if (Mana >= card1.ManaCost && CardsOnBoard.Count < 5)
        {
            Mana -= card1.ManaCost;
            CardsOnBoard.Add(card1);
            Hand.Remove(card1);
            //If you ask for the removal of an element that isn't in the collection, it doesn't throw exception, 
            //if element belongs it removes it, otherwise it continues to next line of code.

        }
    }
    public void Draw(int cant = 1)
    {
        if (Mana >= 1 && (Hand == null || Hand.Count < 5))//can turn into a method that checks for every action whether or not it is valid
        {
            for (int i = 0; i < cant; i++)
            {
                Hand.Add(Deck[0]);
                Deck.Remove(Deck[0]);
                Mana -= 1;
            }
        }
    }
    public void UpdateSpellsMana()
    {
        List<ISpellCard> spellCards = GetSpellCardsOnBoard();
        foreach (var card in spellCards)
        {
            if (card.LifeTime <= 1)
            {
                CardsOnBoard.Remove(card);
                continue;
            }
            card.SetLifeTime(card.LifeTime-1);
        }
    }

    public List<ISpellCard> GetSpellCardsOnBoard()
    {
        List<ISpellCard> answer = new List<ISpellCard>();
        foreach (var card in CardsOnBoard)
        {
            if (card.Type == CardType.Spell)
            {
                answer.Add((ISpellCard)card);
            }
        }
        return answer;
    }

    internal void StartTurn()
    {
        this.UpdateSpellsMana();
    }
}



