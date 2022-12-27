

namespace BattleCardsLibrary
{
    public class ActionReceiver
    {
        public ICard ExecuterCard { get; private set; }
        public ICard TargetCard { get; private set; }
        public ActionType ActionType { get; private set; }

        public ActionReceiver(ICard executerCard, ICard targetCard, ActionType actionType)
        {
            ExecuterCard = executerCard;
            TargetCard = targetCard;
            ActionType = actionType;
        }
    }
}