using BattleCardsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardDeveloper1.CardEvaluator
{
    public class FalseExpression : IEvaluate
    {
        public double Evaluate(ICard onCard, ICard enemyCard)
        {
            return 0;
        }
    }
}
