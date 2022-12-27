using BattleCardsLibrary.Utils;
using BattleCardsLibrary;
namespace CardDeveloper1.Cards;
public class SpellCard : Card,ISpellCard
{
    public int LifeTime { get; set; }

    public SpellCard(Dictionary<AllCardProperties, string> CardProperties, string[] description) : base(CardProperties, description)
    {
        this.LifeTime = (Int32)CheckIfValueIsNumber(AllCardProperties.LifeTime, CardProperties);
    }
}