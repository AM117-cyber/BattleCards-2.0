namespace BattleCards.Cards;
public class SpellCard : Card
{
    public int LifeTime { get; set; }

    public SpellCard(string[] BasicProperties, int life) : base(BasicProperties)
    {
        LifeTime = life;
    }
}