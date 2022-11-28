using static System.Net.Mime.MediaTypeNames;

namespace BattleCards.Cards;
public class MonsterCard:Card
{
    public double HealthPoints {get; set;}

    public MonsterCard(string[] BasicProperties, double health):base(BasicProperties)
    {
        this.HealthPoints = health;
    }
    
}