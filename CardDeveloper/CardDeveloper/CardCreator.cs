using BattleCardsLibrary;
using BattleCardsLibrary.Utils;
using CardDeveloper.Exceptions;
using CardDeveloper.Cards;
using System.Text.RegularExpressions;
using CardDeveloper.Utils;

namespace CardDeveloper;

// cardcreator toma un string del source y crea una carta con el.
//la funcion del source es darle informacion alICardcreator
public class CardCreator : ICardCreator
{
    /*private static CardCreator? cardCreator;

    private CardCreator(){ }

    public static CardCreator Instance {
        get
        {
            cardCreator ??= new CardCreator();
            return cardCreator;
        }
    }*/
    public CardCreator()
    {

    }


    public ICard CreateCard(string[] CardDefinition)
    {
        if (CardDefinition.Length % 2 != 0)
        {
            throw new NoValueForEachPropertyException("Syntax error, there isn't a value for every property.");
        }
        string cardType = CardDefinition[1].TrimEnd();
        if (cardType != "Monster" && cardType != "Spell")
        {
            throw new InvalidCardTypeException("You must insert a validICardtype.");
        }
        Dictionary<AllCardProperties, string> CardProperties = SetDefaultValuesInSpecificDict(cardType);

        //Enum.GetNames(typeof(AllCardProperties)).Length];
        //text[i].Remove(text[i].Length - 1, 1).Remove(0, 1);
        for (int i = 2; i < CardDefinition.Length - 1; i++)
        {
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
                return new SpellCard(CardProperties, CardDefinition);//because if theICardtype weren't valid an exception would have been thrown at the top.
        }
    }
    private Dictionary<AllCardProperties, string> SetDefaultValuesInSpecificDict(string cardType)
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


    public List<ICard> GetAllCardsList()
    {

        List<ICard> answer = new List<ICard>();
        string[] path = Directory.GetFiles(@"..\..\..\..\CardLibrary");
        foreach (var indivpath in path)
        {
            string[] text = File.ReadAllText(indivpath).Split("\r\n");
            string processedTextAsString = string.Empty;
            foreach (var item in text)
            {
                processedTextAsString += ": " + item;
            }
            string[] textToCreateCard = processedTextAsString.Remove(0, 2).Split(": ");
            answer.Add(this.CreateCard(textToCreateCard));

        }
        return answer;
    }
}
