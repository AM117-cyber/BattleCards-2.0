using static System.Net.Mime.MediaTypeNames;
using BattleCardsLibrary.Utils;
using BattleCardsLibrary.Cards.CardEvaluator;

namespace BattleCardsLibrary.Cards;
public class MonsterCard : Card
{
    
    public IEvaluate Defend { get; set; }

    public MonsterCard(Dictionary<AllCardProperties, string> CardProperties, string[] description) : base(CardProperties,description)
    {
        
        this.Defend = GetExpressionOrDefaultValueAsConstant(AllCardProperties.Defend, CardProperties);
    }

}