using BattleCards.Cards;

namespace BattleCards
{
    public class ActionReceiver
    {
        public Card ExecuterCard { get; private set; }
        public Card TargetCard { get; private set; }
        public ActionType ActionType { get; private set; }

        public ActionReceiver(Card executerCard, Card targetCard, ActionType actionType)
        {
            ExecuterCard = executerCard;
            TargetCard = targetCard;
            ActionType = actionType;
        }
    }
}