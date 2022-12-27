using BattleCardsLibrary.Cards;
using BattleCardsLibrary.PlayerNamespace;
using BattleCardsLibrary.Utils;

namespace BattleCardsLibrary.ExecuteActions;

//se evalua la expresion y se le pasa evaluada(como double) al metodo de la accion
public static class ExecuteAction
{
    public static void Attack(Card onCard, Card enemyCard, double damage)//comprobar si oncard.Owner = currentPlayer
    {
        if (onCard == null || enemyCard == null || onCard.Used || enemyCard.Type != CardType.Monster) return;

        double defenseValue = Defend(enemyCard as MonsterCard, onCard);
        damage -= defenseValue;
        if (damage < 0)
        {
            if (onCard.Type == CardType.Monster)
            {
                (onCard as MonsterCard).OnGameHealth = 0;
                onCard.Owner.CardsOnBoard.Remove(onCard);
            }
        }
        else
        {
            if ((enemyCard as MonsterCard).OnGameHealth <= damage)
            {
                double damageForPlayer = damage - (enemyCard as MonsterCard).OnGameHealth;
                enemyCard.Owner.Health -= damageForPlayer;
                (enemyCard as MonsterCard).OnGameHealth = 0;
                enemyCard.Owner.CardsOnBoard.Remove(enemyCard);
                return;
            }
            (enemyCard as MonsterCard).OnGameHealth -= damage;
        }
        onCard.Used = true;

    }

    public static double Defend(MonsterCard onCard, Card enemyCard)//devuelve el numero que se le va a restar al damage
    {
        double deffense = onCard.Defend.Evaluate(onCard, enemyCard);
        return deffense;
    }
    public static void Heal(Card onCard, Card enemyCard, double healing)
    {
        if (onCard == null || enemyCard == null || onCard.Used || enemyCard.Type != CardType.Monster) return;
        (enemyCard as MonsterCard).OnGameHealth = ((enemyCard as MonsterCard).OnGameHealth + healing) < (enemyCard as MonsterCard).HealthPoints ? (enemyCard as MonsterCard).OnGameHealth + healing : (enemyCard as MonsterCard).HealthPoints;
        onCard.Used = true;
    }
    public static void DirectAttack(Card onCard)
    {
        if (onCard == null || onCard.Used)//esto va en Game || attackingCard.Owner != CurrentPlayer
        {
            return;
        }
        if (Game.CurrentPlayer == 1)
        {
            Game.Player2.Health -= NoMonstersOnBoard(Game.Player2) ? onCard.Damage : 0;
        }
        else
        {
            Game.Player1.Health -= NoMonstersOnBoard(Game.Player1) ? onCard.Damage : 0;
        }
        onCard.Used = true;
    }
    public static bool NoMonstersOnBoard(Player player)
    {
        foreach (var card in player.CardsOnBoard)
        {
            if (card.Type == CardType.Monster)
            {
                return false;
            }
        }
        return true;
    }
}





/*string textOfCard = File.ReadAllLines();

string[] contentOfCard = new string[10];

     void TextProcessor(string textOfCard)
    {
      contentOfCard = textOfCard.Split(' ') ;
      foreach (var item in contentOfCard)
      {
        System.Console.WriteLine(item);
      }
    }*/