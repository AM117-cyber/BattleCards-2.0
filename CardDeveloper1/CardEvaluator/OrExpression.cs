using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleCardsLibrary.Utils;

namespace CardDeveloper.CardEvaluator
{
    public class OrExpression : ConditionalBinaryExpression
    {
        public OrExpression(string left, string right, CardType type) : base(left, right, type)
        {

        }
        public override double Evaluate(double leftValue, double rightValue)
        {
            return leftValue == 1 || rightValue == 1 ? 1 : 0;
        }
    }
}
