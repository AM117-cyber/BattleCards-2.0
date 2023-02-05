using BattleCardsLibrary;

namespace CardDeveloper.CardEvaluator
{
    public abstract class BinaryExpression : IEvaluable
    {
        public IEvaluable Left { get; set; } // el operador no hace falta porque cuando se construye ya debe saber quien es
        public IEvaluable Right { get; set; }

        public double Evaluate(ICard onCard, ICard enemyCard)//
        {
            double leftValue = Left.Evaluate(onCard, enemyCard);
            double rightValue = Right.Evaluate(onCard, enemyCard);

            return Evaluate(leftValue, rightValue);
        }

        public abstract double Evaluate(double leftValue, double rightValue);
    }
}
