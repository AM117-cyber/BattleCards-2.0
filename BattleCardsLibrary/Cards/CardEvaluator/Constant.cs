using BattleCardsLibrary.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCardsLibrary.Cards.CardEvaluator
{
    public class Constant : IEvaluate
    {
        public double Value;

        public Constant(double value)
        {
            Value = value; //puede ser Double.Parse(value).
        }
        public double Evaluate(Card onCard, Card enemyCard)
        {
            return Value;
        }
    }
}
