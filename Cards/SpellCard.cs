namespace BattleCards.Cards;
public class SpellCard: Card
{
    public int LifeTime {get; private set;}

    public SpellCard(string[] BasicProperties, int life) : base(BasicProperties)
    {
        this.LifeTime = life;
    }
}