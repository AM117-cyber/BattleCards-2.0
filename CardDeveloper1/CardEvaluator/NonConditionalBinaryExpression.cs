using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleCardsLibrary.Utils;

namespace CardDeveloper.CardEvaluator
{
    public abstract class NonConditionalBinaryExpression : BinaryExpression
    {
        public NonConditionalBinaryExpression(string left, string right, CardType type)
        {
            Left = Interpreter.BuildExpression(left, type);
            Right = Interpreter.BuildExpression(right, type);
        }
    }
}
