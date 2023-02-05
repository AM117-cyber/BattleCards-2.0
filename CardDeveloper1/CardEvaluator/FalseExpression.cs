using BattleCardsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardDeveloper.CardEvaluator
{
    public class FalseExpression : IEvaluable
    {
        public double Evaluate(ICard onCard, ICard enemyCard)
        {
            return 0;
        }
    }
}
