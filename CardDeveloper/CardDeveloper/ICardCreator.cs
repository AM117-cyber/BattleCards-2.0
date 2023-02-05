using BattleCardsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardDeveloper
{
    public interface ICardCreator
    {
        public ICard CreateCard(string[] CardDefinition);
    }
}
