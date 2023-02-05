using System;
using System.Collections.Generic;
using System.Linq;
using CardDeveloper.Exceptions;
using System.Text;
using System.Threading.Tasks;
using BattleCardsLibrary.Utils;

namespace CardDeveloper.CardEvaluator
{
    public class HigherThanOperatorExpression : NonConditionalBinaryExpression
    {
        public HigherThanOperatorExpression(string left, string right, CardType type) : base(left, right, type)
        {

        }

        public override double Evaluate(double leftValue, double rightValue)
        {
            return leftValue > rightValue ? 1 : 0;
        }
    }
}
