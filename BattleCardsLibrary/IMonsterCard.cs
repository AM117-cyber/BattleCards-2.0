using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCardsLibrary
{
    public interface IMonsterCard: ICard
    {
        public IEvaluate Defend { get; set; }
    }
}
