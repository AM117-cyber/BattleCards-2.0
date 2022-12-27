using BattleCardsLibrary.Cards;
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
        public List<MonsterCard> GetMonsterCardsOnBoard(List<Card> enemysCards);
        public (MonsterCard, bool) YouNeedAHealerCard();

    }
}
