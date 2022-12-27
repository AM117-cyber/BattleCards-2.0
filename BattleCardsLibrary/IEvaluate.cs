
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCardsLibrary
{
    public interface IEvaluate
    {
        public double Evaluate(ICard onCard, ICard enemyCard);
    }
}
