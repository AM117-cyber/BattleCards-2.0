using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageToCreateCards.Cards;

namespace LanguageToCreateCards.CardDeveloper
{
    public class CardSaver : ICardSaver
    {
        public void SaveCard(string[] cardDefinition, string nameOfCard)
        {
            string title = nameOfCard;
            string path = @"..\CardLibrary\" + title + ".txt";//D:\BattleCards\BattleCardsLibrary
            string contentOfTxT = Card.GetCardDescription(cardDefinition);
            File.WriteAllText(path, contentOfTxT.TrimEnd());
            //File.WriteAllText(path, this.card_exp.Text);
        }
    }

   
}
