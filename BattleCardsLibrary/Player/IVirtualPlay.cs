
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCardsLibrary.PlayerNamespace
{
    public interface IVirtualPlay
    {
        public void Play();
        public List<IMonsterCard> GetMonsterCardsOnBoard(List<ICard> enemysCards);
        public (IMonsterCard, bool) YouNeedAHealerCard();

    }
}
