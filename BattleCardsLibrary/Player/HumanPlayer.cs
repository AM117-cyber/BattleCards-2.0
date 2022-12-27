using BattleCardsLibrary.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleCardsLibrary.Utils;

namespace BattleCardsLibrary.PlayerNamespace
{
    public class HumanPlayer : Player
    {
        public HumanPlayer(string name, List<Card> deck, int n) : base(name, deck, n)
        {
            Type = PlayerType.Human;
        }



    }
}
