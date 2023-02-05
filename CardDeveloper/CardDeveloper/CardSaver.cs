using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleCardsLibrary;

namespace CardDeveloper;

public class CardSaver:ICardSaver
{
    string Path = @"..\..\..\..\CardLibrary\";
    /*private static CardSaver cardSaver;

    private CardSaver() { }

    public static CardSaver Instance
    {
        get
        {
            cardSaver ??= new CardSaver();
            return cardSaver;
        }
    }*/
    public CardSaver()
    {

    }
    public void SaveCard(string CardDefinition, string NameForTitle)
    {
        string pathToSaveCard = this.Path + NameForTitle + ".txt";//D:\BattleCards\BattleCardsLibrary
        File.WriteAllText(pathToSaveCard, CardDefinition.TrimEnd());
        //File.WriteAllText(path, this.card_exp.Text);
    }
}
