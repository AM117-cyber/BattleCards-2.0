using BattleCards.Cards;
namespace BattleCards.Actions;

//se evalua la expresion y se le pasa evaluada(como double) al metodo de la accion
public static class Actions
{
    public static void Attack(Card onCard, MonsterCard enemyCard, double damage)
    {
        double DeffenseValue = Deffend(onCard, enemyCard);
        damage -= DeffenseValue;
        enemyCard.OnGameHealth -= damage < 0 ? 0 : damage;

    }

    public static double Deffend(Card onCard,MonsterCard enemyCard)//devuelve el numero que se le va a restar al damage
    {
        double deffense = onCard.Deffend.Evaluate(onCard,enemyCard);
        return deffense;
    }
    public static void Heal(Card onCard, MonsterCard enemyCard, double healing)
    {
        enemyCard.OnGameHealth += healing;  
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