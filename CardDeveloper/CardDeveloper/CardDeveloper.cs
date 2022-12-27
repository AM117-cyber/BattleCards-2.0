
using BattleCardsLibrary.Exceptions;
using LanguageToCreateCards.UtilsForLanguage;

namespace BattleCardsLibrary.Cards.CardDeveloper;

// cardcreator toma un string del source y crea una carta con el.
//la funcion del source es darle informacion al card creator
public class CardCreator : ICardCreator
{
    private static CardCreator cardCreator;

    private CardCreator(){ }

    public static CardCreator Instance {
        get
        {
            cardCreator ??= new CardCreator();
            return cardCreator;
        }
    }

    public static string GetCardDescription(string[] cardDefinition)
    {
        string contentOfTxT = string.Empty;
        for (int i = 0; i < cardDefinition.Length; i++)
        {
            if (cardDefinition[i] == null)
            {
                continue;
            }
            contentOfTxT += cardDefinition[i++] + ": " + cardDefinition[i] + "\r\n";
        }
        return contentOfTxT;
    }
    public Card CreateCard(string[] CardDefinition)
    {
        if (CardDefinition.Length % 2 != 0)
        {
            throw new NoValueForEachPropertyException("Syntax error, there isn't a value for every property.");
        }
        string cardType = CardDefinition[1].TrimEnd();
        if (cardType != "Monster" && cardType != "Spell")
        {
            throw new InvalidCardTypeException("You must insert a valid card type.");
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
            foreach (var property in Enum.GetValues(typeof(AllCardProperties)).Cast<AllCardProperties>())
            {
                string item = property.ToString();
                if (CardDefinition[i].TrimEnd() == item)
                {
                    if (item == "HealthPoints" && CardProperties[AllCardProperties.Type] != "Monster" || item == "LifeTime" && CardProperties[AllCardProperties.Type] != "Spell")
                    {
                        throw new InvalidPropertyForCardTypeException("Health parameter is only for monsters and lifetime parameter is only for spells.They are not exchangable.");
                    }
                    if ((item == "Defend" || item == "Armour") && CardProperties[AllCardProperties.Type] != "Monster")
                    {
                        throw new SpellsDontHaveDefenseException(item + " property is not valid for " + CardProperties[AllCardProperties.Type]);
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
                throw new InvalidPropertyException("You typed an invalid property.");
            }
            i++;
        }//dictionary's been filled with values given from user
        if (!CardProperties.ContainsKey(AllCardProperties.Name))
        {
            throw new NamelessCardException("All cards must have a name.");
        }


        switch (cardType)
        {
            case "Monster":
                return new MonsterCard(CardProperties, CardDefinition);
            default:
                return new SpellCard(CardProperties, CardDefinition);//because if the card type weren't valid an exception would have been thrown at the top.
        }
    }
    private static Dictionary<AllCardProperties, string> SetDefaultValuesInSpecificDict(string cardType)
    {
        Dictionary<AllCardProperties, string> dictToReturn = new Dictionary<AllCardProperties, string>();
        dictToReturn[AllCardProperties.Type] = cardType;
        dictToReturn[AllCardProperties.ManaCost] = "5";
        dictToReturn[AllCardProperties.Damage] = cardType == "Monster" ? "50" : "0";
        dictToReturn[AllCardProperties.Armour] = cardType == "Monster" ? "10" : "0";//las cartas magicas nunca van a tener este parametro
        dictToReturn[AllCardProperties.HealthPoints] = cardType == "Monster" ? "100" : "0";
        dictToReturn[AllCardProperties.LifeTime] = "1";
        dictToReturn[AllCardProperties.HealingPowers] = cardType == "Monster" ? "0" : "50";

        return dictToReturn;
    }
}
