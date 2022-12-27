using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageToCreateCards.CardDeveloper
{
    internal interface ICardSaver
    {
        public void SaveCard(string[] cardDefinition, string nameOfCard);
    }
}
