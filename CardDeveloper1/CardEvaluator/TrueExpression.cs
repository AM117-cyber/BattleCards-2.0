
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleCardsLibrary;

namespace CardDeveloper.CardEvaluator
{
    public class TrueExpression : IEvaluable
    {
        public double Evaluate(ICard onCard, ICard enemyCard)
        {
            return 1;
        }
    }
}
