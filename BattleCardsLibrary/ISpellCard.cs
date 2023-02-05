using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCardsLibrary
{
    public interface ISpellCard: ICard
    {
        public int LifeTime { get; }
        public void SetLifeTime(int lifeTime);
    }
}
