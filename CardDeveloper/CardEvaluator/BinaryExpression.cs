using LanguageToCreateCards.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCardsLibrary.Cards.CardEvaluator
{
    public abstract class BinaryExpression : IEvaluate
    {
        public IEvaluate Left { get; set; } // el operador no hace falta porque cuando se construye ya debe saber quien es
        public IEvaluate Right { get; set; }

        public double Evaluate(Card onCard, Card enemyCard)//
        {
            double leftValue = Left.Evaluate(onCard, enemyCard);
            double rightValue = Right.Evaluate(onCard, enemyCard);

            return Evaluate(leftValue, rightValue);
        }

        public abstract double Evaluate(double leftValue, double rightValue);
    }
}
