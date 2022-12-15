using static Utils.Utils;
namespace BattleCards.Cards;
public class SpellCard : Card
{
    public int LifeTime { get; set; }

    public SpellCard(Dictionary<AllCardProperties, string> CardProperties) : base(CardProperties)
    {
        int value;
        if (!Int32.TryParse(CardProperties[AllCardProperties.LifeTime], out value))
        {
            throw new Exception("The value corresponding to lifetime property isn't a number.");
        }
        LifeTime = value;
    }
}