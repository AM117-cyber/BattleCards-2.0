using static System.Net.Mime.MediaTypeNames;
using BattleCardsLibrary.Utils;
using BattleCardsLibrary;
using CardDeveloper1.CardEvaluator;

namespace CardDeveloper1.Cards;
public class MonsterCard : Card,IMonsterCard
{
    
    public IEvaluate Defend { get; set; }

    public MonsterCard(Dictionary<AllCardProperties, string> CardProperties, string[] description) : base(CardProperties,description)
    {
        
        this.Defend = GetExpressionOrDefaultValueAsConstant(AllCardProperties.Defend, CardProperties);
    }

}