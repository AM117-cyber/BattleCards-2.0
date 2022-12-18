using BattleCards.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Utils.Utils;

namespace BattleCardsLibrary.Cards;

// cardcreator toma un string del source y crea una carta con el.
//la funcion del source es darle informacion al card creator

public interface ICardCreatorSource
{
    public string[] GetCardDefinition();

}
public interface ICardCreator
{
    public Card CreateCard(string[] CardDefinition);
}

public interface ICardValidator
{
    public string[] CardDefinition { get; set; }
    public Card Card { get; set; }
    public ICardCreatorSource Source { get; }
    public ICardCreator CardCreator { get; }
    public bool CheckIfCardIsValid();

}
public class CardCreator : ICardCreator
{
    public CardCreator()
    {

    }
    public Card CreateCard(string[] CardDefinition)
    {
        if ((CardDefinition.Length % 2) != 0)
        {
            throw new Exception("Syntax error, there isn't a value for every property.");
        }
        string cardType = CardDefinition[1].TrimEnd();
        if (cardType != "Monster" && cardType != "Spell")
        {
            throw new Exception("You must insert a valid card type.");
        }
        Dictionary<AllCardProperties, string> CardProperties = SetDefaultValuesInSpecificDict(cardType);

        //Enum.GetNames(typeof(AllCardProperties)).Length];
        //text[i].Remove(text[i].Length - 1, 1).Remove(0, 1);
        for (int i = 2; i < CardDefinition.Length - 1; i++)
        {
            if (CardDefinition[i] == null)
            {
                continue;
            }
            bool propertyIsValid = false;
            foreach (var property in (Enum.GetValues(typeof(AllCardProperties))).Cast<AllCardProperties>())
            {
                string item = property.ToString();
                if (CardDefinition[i].TrimEnd() == item)
                {
                    if ((item == "HealthPoints" && CardProperties[AllCardProperties.Type] != "Monster") || (item == "LifeTime" && CardProperties[AllCardProperties.Type] != "Spell"))
                    {
                        throw new Exception("Health parameter is only for monsters and lifetime parameter is only for spells.They are not exchangable.");
                    }
                    if (item == "Defend" && CardProperties[AllCardProperties.Type] != "Monster")
                    {
                        throw new Exception("Spells' value to increase a card's defense can only be expressed as a constant value in this version.");
                    }
                    //if it doesn't throw Exception the property is valid hence, you add it to dictionary.
                    CardProperties[property] = CardDefinition[i + 1].TrimEnd();
                    if (item != "Name")
                    {
                        CardProperties[property] = CardProperties[property].Replace(" ", "");
                    }
                    propertyIsValid = true;
                    break;
                }
            }
            if (!propertyIsValid)
            {
                throw new Exception("You typed an invalid property.");
            }
            i++;
        }//dictionary's been filled with values given from user
        if (!CardProperties.ContainsKey(AllCardProperties.Name))
        {
            throw new Exception("All cards must have a name.");
        }


        switch (cardType)
        {
            case "Monster":
                return new MonsterCard(CardProperties);
            default:
                return new SpellCard(CardProperties);//because if the card type weren't valid an exception would have been thrown at the top.
        }
    }
    public static Dictionary<AllCardProperties, string> SetDefaultValuesInSpecificDict(string cardType)
    {
        Dictionary<AllCardProperties, string> dictToReturn = new Dictionary<AllCardProperties, string>();
        dictToReturn[AllCardProperties.Type] = cardType;
        dictToReturn[AllCardProperties.ManaCost] = "5";
        dictToReturn[AllCardProperties.Damage] = cardType == "Monster" ? "50" : "0";
        dictToReturn[AllCardProperties.Armour] = cardType == "Monster" ? "10" : "0";//las cartas magicas nunca van a tener este parametro
        dictToReturn[AllCardProperties.HealthPoints] = "100";
        dictToReturn[AllCardProperties.LifeTime] = "1";
        dictToReturn[AllCardProperties.HealingPowers] = cardType == "Monster" ? "0" : "50";

        return dictToReturn;

    }
}
