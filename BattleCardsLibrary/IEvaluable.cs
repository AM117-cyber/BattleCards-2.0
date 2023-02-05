namespace BattleCardsLibrary
{
    public interface IEvaluable
    {
        public double Evaluate(ICard onCard, ICard enemyCard);
    }
}
