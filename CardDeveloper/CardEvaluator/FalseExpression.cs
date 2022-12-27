using LanguageToCreateCards.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCardsLibrary.Cards.CardEvaluator
{
    public class FalseExpression : IEvaluate
    {
        public double Evaluate(Card onCard, Card enemyCard)
        {
            return 0;
        }
    }
}
