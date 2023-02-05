using BattleCardsLibrary.Utils;

namespace BattleCardsLibrary
{
    public interface IMonsterCard : ICard
    {
        public IEvaluable Defend { get; }
        public void DefendFrom(ICard attackingCard, double attack);
        public void SetOnGameHealth(double health);
        public bool NeedsHealing();


    }
}
