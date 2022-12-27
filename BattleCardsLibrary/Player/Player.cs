using BattleCardsLibrary;
using BattleCardsLibrary.Cards;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using BattleCardsLibrary.Utils;
namespace BattleCardsLibrary.PlayerNamespace;



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

    public Player(string name, List<Card> deck, int number)
    {
        Type = PlayerType.Human;
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
        Hand = new List<Card>();
        CardsOnBoard = new List<Card>();
    }

    public void MarkCardsAsUnused()
    {
        foreach (var card in CardsOnBoard)
        {
            card.Used = false;
        }
    }
    public void Shuffle()
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
        if (Mana >= card1.ManaCost && CardsOnBoard.Count < 5)
        {
            Mana -= card1.ManaCost;
            CardsOnBoard.Add(card1);
            Hand.Remove(card1);
            //If you ask for the removal of an element that isn't in the collection, it doesn't throw exception, 
            //if element belongs it removes it, otherwise it continues to next line of code.

        }
    }
    public void Draw(int cant)
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
        List<SpellCard> spellCards = GetSpellCardsOnBoard();
        foreach (var card in spellCards)
        {
            if (card.LifeTime <= 1)
            {
                CardsOnBoard.Remove(card);
                continue;
            }
            card.LifeTime--;
        }
    }

    public List<SpellCard> GetSpellCardsOnBoard()
    {
        List<SpellCard> answer = new List<SpellCard>();
        foreach (var card in CardsOnBoard)
        {
            if (card.Type == CardType.Spell)
            {
                answer.Add((SpellCard)card);
            }
        }
        return answer;
    }


}



