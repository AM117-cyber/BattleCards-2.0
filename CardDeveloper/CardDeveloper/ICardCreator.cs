using LanguageToCreateCards.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCardsLibrary.Cards.CardDeveloper
{
    public interface ICardCreator
    {
        public Card CreateCard(string[] CardDefinition);
    }
}
