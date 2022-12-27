using BattleCardsLibrary.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleCardsLibrary.Utils;

namespace BattleCardsLibrary.Cards.CardEvaluator
{
    public class TernaryExpression : IEvaluate
    {
        public IEvaluate Condition { get; set; }
        public IEvaluate IfTrue { get; set; }
        public IEvaluate Else { get; set; }

        public TernaryExpression(string ternaryExpression, CardType type)
        {
            string[] SeparatedExpressions = Interpreter.SepareTernaryExpression(ternaryExpression, 3);
            Condition = Interpreter.BuildConditionalExpression(SeparatedExpressions[0], type);
            IfTrue = Interpreter.BuildExpression(SeparatedExpressions[1], type);
            Else = Interpreter.BuildExpression(SeparatedExpressions[2], type);
        }


        public double Evaluate(Card onCard, Card enemyCard)
        {
            if (Condition.Evaluate(onCard, enemyCard) == 1)
            {
                return IfTrue.Evaluate(onCard, enemyCard);
            }
            return Else.Evaluate(onCard, enemyCard);
        }
    }
}
