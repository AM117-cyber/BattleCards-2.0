using static System.Net.Mime.MediaTypeNames;

namespace BattleCards.Cards;
public class MonsterCard : Card
{
    public double HealthPoints { get; private set; }
    public double OnGameHealth { get; set; }

    public MonsterCard(string[] BasicProperties, double health) : base(BasicProperties)
    {
        HealthPoints = health;
        OnGameHealth = health;
    }

}