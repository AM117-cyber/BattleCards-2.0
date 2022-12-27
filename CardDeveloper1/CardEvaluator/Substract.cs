using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleCardsLibrary.Utils;

namespace CardDeveloper1.CardEvaluator
{
    public class Substract : NonConditionalBinaryExpression
    {
        public Substract(string left, string right, CardType type) : base(left, right, type)
        {

        }
        public override double Evaluate(double leftValue, double rightValue)
        {
            return leftValue > rightValue ? leftValue - rightValue : 0;
        }
    }
}
