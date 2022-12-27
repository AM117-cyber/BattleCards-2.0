using BattleCardsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardDeveloper1.CardEvaluator
{
    public class Constant : IEvaluate
    {
        public double Value;

        public Constant(double value)
        {
            Value = value; //puede ser Double.Parse(value).
        }
        public double Evaluate(ICard onCard, ICard enemyCard)
        {
            return Value;
        }
    }
}
