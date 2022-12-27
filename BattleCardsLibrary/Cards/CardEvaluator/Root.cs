using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleCardsLibrary.Utils;

namespace BattleCardsLibrary.Cards.CardEvaluator
{
    public class Root : NonConditionalBinaryExpression
    {
        public Root(string left, string right, CardType type) : base(left, right, type)
        {

        }
        public override double Evaluate(double leftValue, double rightValue)
        {
            if (leftValue < 0 && rightValue % 2 == 0)
            {
                throw new Exception($"You can't get the {rightValue} root of this number.");
            }
            double pow = 1 / rightValue;
            return Math.Pow(leftValue, pow);
        }
    }

}
