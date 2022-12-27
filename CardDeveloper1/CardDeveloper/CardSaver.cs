using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleCardsLibrary;

namespace CardDeveloper1;

public class CardSaver:ICardSaver
{
    private static CardSaver cardSaver;

    private CardSaver() { }

    public static CardSaver Instance
    {
        get
        {
            cardSaver ??= new CardSaver();
            return cardSaver;
        }
    }
    public void SaveCard(string[] CardDefinition, string CardName)
    {
        string title = CardName;
        string path = @"..\CardLibrary\" + title + ".txt";//D:\BattleCards\BattleCardsLibrary
        string contentOfTxT = ICard.GetCardDescription(CardDefinition);
        File.WriteAllText(path, contentOfTxT.TrimEnd());
        //File.WriteAllText(path, this.card_exp.Text);
    }
}
