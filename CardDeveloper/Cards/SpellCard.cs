using BattleCardsLibrary.Utils;
using BattleCardsLibrary;
using CardDeveloper.Utils;

namespace CardDeveloper.Cards;
public class SpellCard : Card, ISpellCard
{
    public int LifeTime { get; private set; }

    public SpellCard(Dictionary<AllCardProperties, string> CardProperties, string[] description) : base(CardProperties, description)
    {
        this.LifeTime = (int)CheckIfValueIsNumber(AllCardProperties.LifeTime, CardProperties);
    }
    public void UpdateLifeTimeForTurn()
    {
        this.LifeTime --;
    }
   
}