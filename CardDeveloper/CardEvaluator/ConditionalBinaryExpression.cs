using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageToCreateCards.UtilsForLanguage;

namespace BattleCardsLibrary.Cards.CardEvaluator
{
    public abstract class ConditionalBinaryExpression : BinaryExpression
    {
        public ConditionalBinaryExpression(string left, string right, CardType type)
        {
            Left = Interpreter.BuildConditionalExpression(left, type);
            Right = Interpreter.BuildConditionalExpression(right, type);
        }
    }
}
