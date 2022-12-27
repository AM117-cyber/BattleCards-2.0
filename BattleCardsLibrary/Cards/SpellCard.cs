using BattleCardsLibrary.Utils;
namespace BattleCardsLibrary.Cards;
public class SpellCard : Card
{
    public int LifeTime { get; set; }

    public SpellCard(Dictionary<AllCardProperties, string> CardProperties, string[] description) : base(CardProperties, description)
    {
        this.LifeTime = (Int32)CheckIfValueIsNumber(AllCardProperties.LifeTime, CardProperties);
    }
}