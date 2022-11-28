using BattleCards.Cards;
namespace BattleCards.Actions;

//se evalua la expresion y se le pasa evaluada(como double) al metodo de la accion
public static class Actions
{
    public static void Attack(MonsterCard enemyCard, double damage)
    {
        double DeffenseValue = Deffend(enemyCard);
        damage -= DeffenseValue;
        enemyCard.HealthPoints -= damage < 0 ? 0 : damage;

    }

    public static double Deffend(MonsterCard onCard)//devuelve el numero que se le va a restar al damage
    {
        double deffense = Evaluator.EvaluateExpression(onCard.Deffend);
        return deffense;
    }
    public static double Heal(MonsterCard onCard, double damage)//devuelve el numero que se le va a restar al damage
    {
        double deffense = Evaluator.EvaluateExpression(onCard.Deffend);
        return deffense;
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