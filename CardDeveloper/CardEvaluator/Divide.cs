using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageToCreateCards.UtilsForLanguage;

namespace BattleCardsLibrary.Cards.CardEvaluator
{
    public class Divide : NonConditionalBinaryExpression
    {
        public Divide(string left, string right, CardType type) : base(left, right, type)
        {

        }
        public override double Evaluate(double leftValue, double rightValue)
        {
            if (rightValue == 0)
            {
                return double.MaxValue;//dividing by 0 returns infinite, but is pointless in this game, so you return the highest value possible
            }
            return leftValue / rightValue;
        }
    }
}
