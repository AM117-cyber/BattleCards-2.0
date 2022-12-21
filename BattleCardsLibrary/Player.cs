using BattleCards.Cards;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using static Utils.Utils;
namespace BattleCards;

public interface IVirtualPlay
{
    public void Play();
    public List<MonsterCard> GetMonsterCardsOnBoard(List<Card> enemysCards);
    public (MonsterCard, bool) YouNeedAHealerCard();

}
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
        this.Type = PlayerType.Human;
        this.Number = number;
        this.Name = name;
        this.Health = 1000;
        this.Mana = 20;
        this.Deck = deck;
        foreach (var card in Deck)
        {
            card.Owner = this;
        }
        Shuffle();
        this.Hand = new List<Card>();
        this.CardsOnBoard = new List<Card>();
    }

    public void MarkCardsAsUnused()
    {
        foreach (var card in this.CardsOnBoard)
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
        if (this.Mana >= card1.ManaCost && this.CardsOnBoard.Count < 5)
        {
            this.Mana -= card1.ManaCost;
            this.CardsOnBoard.Add(card1);
            this.Hand.Remove(card1);

        }
    }
    public void Draw(int cant)
    {
        if (this.Mana > 1 && (this.Hand == null || this.Hand.Count < 5))//can turn into a method that checks for every action whether or not it is valid
        {
            for (int i = 0; i < cant; i++)
            {
                Hand.Add(Deck[0]);
                Deck.Remove(Deck[0]);
                this.Mana -= 1;
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
        foreach (var card in this.CardsOnBoard)
        {
            if (card.Type == CardType.Spell)
            {
                answer.Add((SpellCard)card);
            }
        }
        return answer;
    }


}

public class HumanPlayer : Player
{
    public HumanPlayer(string name, List<Card> deck, int n) : base(name, deck, n)
    {
        Type = PlayerType.Human;
    }



}
public class AIPlayer : Player, IVirtualPlay
{
    private Player player;
    private Card cardToInvokeAndActivate = null;
    private MonsterCard targetCard = null;
    private ActionsByPlayer effect = ActionsByPlayer.TurnIsOver;
    public AIPlayer(string name, List<Card> deck, int n) : base(name, deck, n)
    {
        Type = PlayerType.GreedyAI;
    }

    public void Play()//pasa por todas las jugadas validas y envia la mejor
    {
        if (player == null)
        {
            player = Game.GetCurrentPlayer();
        }

        if (Game.CurrentPhase == Phase.MainPhase)
        {//MainPhase actions

            //first you invoke
            if (player.Hand.Count != 0)
            {
                (cardToInvokeAndActivate, targetCard, effect) = GetCardToInvoke();
                Game.CardActionReceiver(ActionsByPlayer.InvokeCard, cardToInvokeAndActivate, null, 1);
            }

            //then you draw from deck if you can
            if (this.Hand.Count < 5 && this.Mana >= 1)
            {
                Game.CardActionReceiver(ActionsByPlayer.DrawFromDeck, null, null, player.Number);
            }
            Game.CardActionReceiver(ActionsByPlayer.TurnIsOver, null, null, 1);
            return;
        }
        if (Game.CurrentPhase == Phase.BattlePhase)
        {
            //BattlePhase actions
            if (effect != ActionsByPlayer.TurnIsOver)
            {
                Game.CardActionReceiver(effect, cardToInvokeAndActivate, targetCard, 1);
                effect = ActionsByPlayer.TurnIsOver;
                cardToInvokeAndActivate = null;
                targetCard = null;
                return;
            }

            List<MonsterCard> enemyPlayersMonsters = GetMonsterCardsOnBoard(this.Number == 1 ? Game.Player2.CardsOnBoard : Game.Player1.CardsOnBoard);
            for (int i = 0; i < this.CardsOnBoard.Count; i++)
            {
                if (i < enemyPlayersMonsters.Count)
                {
                    Game.CardActionReceiver(ActionsByPlayer.Attack, this.CardsOnBoard[i], enemyPlayersMonsters[i], 1);

                }
                else
                {
                    Game.CardActionReceiver(ActionsByPlayer.DirectAttack, this.CardsOnBoard[i], null, 1);
                }

            }
            Game.CardActionReceiver(ActionsByPlayer.TurnIsOver, null, null, 1);
        }
    }

    public (Card, MonsterCard, ActionsByPlayer) GetCardToInvoke()
    {
        Card cardToInvoke = null;
        double valueOfEffect = 0;
        (MonsterCard card, bool IsTrue) needAHealerCard = YouNeedAHealerCard();
        if (needAHealerCard.IsTrue)
        {
            foreach (Card card in this.CardsOnBoard)
            {
                if (card.ManaCost <= this.Mana)
                {
                    double actualHealing = card.Heal.Evaluate(card, needAHealerCard.card);
                    if (actualHealing > valueOfEffect)
                    {
                        valueOfEffect = actualHealing;
                        cardToInvoke = card;
                    }
                }
            }
            if (valueOfEffect != 0)
            {
                return (cardToInvoke, needAHealerCard.card, ActionsByPlayer.Heal);
            }//if you get here you coudn't invoke a spellcard
        }
        MonsterCard victimCard = null;
        List<MonsterCard> monstersOnEnemysSide = GetMonsterCardsOnBoard(this.Number == 1 ? Game.Player2.CardsOnBoard : Game.Player1.CardsOnBoard);
        foreach (Card myCard in this.Hand)
        {
            if (myCard.ManaCost <= this.Mana && (myCard.Damage != 0 || myCard.Attack.Evaluate(myCard,myCard) != 0))
            {//Card is invokable
                foreach (MonsterCard enemyCard in monstersOnEnemysSide)
                {
                    double actualAttacking = myCard.Attack.Evaluate(myCard, enemyCard);
                    if (actualAttacking > valueOfEffect)
                    {
                        valueOfEffect = actualAttacking;
                        cardToInvoke = myCard;
                        victimCard = enemyCard;
                    }
                }
                if (monstersOnEnemysSide.Count == 0)
                {
                    return (myCard, null, ActionsByPlayer.DirectAttack);
                }

            }
        }
        return (cardToInvoke, victimCard, ActionsByPlayer.Attack);



    }

    public List<MonsterCard> GetMonsterCardsOnBoard(List<Card> enemysCards)
    {
        List<MonsterCard> answer = new List<MonsterCard>();
        foreach (var card in enemysCards)
        {
            if (card.Type == CardType.Monster)
            {
                answer.Add((MonsterCard)card);
            }
        }
        return answer;
    }

    public (MonsterCard, bool) YouNeedAHealerCard()
    {
        List<MonsterCard> myMonsters = GetMonsterCardsOnBoard(this.CardsOnBoard);
        foreach (MonsterCard monster in myMonsters)
        {
            if (monster.OnGameHealth < monster.HealthPoints)
            {
                return (monster, true);
            }
        }
        return (null, false);
    }
}
