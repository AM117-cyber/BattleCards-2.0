using BattleCardsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardDeveloper.CardEvaluator
{
    public class Constant : IEvaluable
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
