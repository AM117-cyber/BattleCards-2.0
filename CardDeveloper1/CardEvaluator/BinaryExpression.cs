using BattleCardsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardDeveloper1.CardEvaluator
{
    public abstract class BinaryExpression : IEvaluate
    {
        public IEvaluate Left { get; set; } // el operador no hace falta porque cuando se construye ya debe saber quien es
        public IEvaluate Right { get; set; }

        public double Evaluate(ICard onCard, ICard enemyCard)//
        {
            double leftValue = Left.Evaluate(onCard, enemyCard);
            double rightValue = Right.Evaluate(onCard, enemyCard);

            return Evaluate(leftValue, rightValue);
        }

        public abstract double Evaluate(double leftValue, double rightValue);
    }
}
