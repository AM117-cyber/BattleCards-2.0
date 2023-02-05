using BattleCardsLibrary.Utils;

namespace BattleCardsLibrary
{
    public interface IMonsterCard : ICard
    {
        public IEvaluable Defend { get; }
        public double DefendFrom(ICard attackingCard, double attack);
        public void ReceiveHealing(double healingPoints);
        public bool NeedsHealing();


    }
}
