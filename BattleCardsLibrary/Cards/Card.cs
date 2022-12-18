using BattleCards;
using System.Runtime.CompilerServices;

namespace BattleCards.Cards;

using static Utils.Utils;

public abstract class Card
{
    static Dictionary<AllCardProperties, AllCardProperties> ExtraPropertiesDefaultValue = SetValues();
    public double ManaCost { get; set; }
    public CardType Type { get; set; }
    public Player Owner { get; set; }
    public bool Used { get; set; }
    public string Name { get; set; }
    public double Damage { get; private set; }
    public double Armour { get; private set; }
    public double HealingPowers { get; private set; }
    public IEvaluate Attack { get; set; }   //lo que se guarda aqui es una TernaryExpression que cuando se evalua devuelve double
    public IEvaluate Heal { get; set; }  //heal se pueden hacer separadas despues en dependencia de la prop, improve health seria heal por ejemplo
    //public string Deffend { get; set;}  // protected de algun tipo? no quiero que salga entre opciones de carta para jugador podria hacerse con if !=
    public IEvaluate Defend { get; set; }

    public Card(Dictionary<AllCardProperties, string> CardProperties)
    {
        this.Type = CardProperties[AllCardProperties.Type] == "Monster" ? CardType.Monster : CardType.Spell;
        this.Name = CardProperties[AllCardProperties.Name];
        this.Owner = null;
        this.Used = false;
        this.ManaCost = CheckIfValueIsNumber(AllCardProperties.ManaCost, CardProperties);
        this.Damage = CheckIfValueIsNumber(AllCardProperties.Damage, CardProperties);
        this.Armour = CheckIfValueIsNumber(AllCardProperties.Armour, CardProperties);
        this.HealingPowers = CheckIfValueIsNumber(AllCardProperties.HealingPowers, CardProperties);
        this.Attack = GetExpressionOrDefaultValueAsConstant(AllCardProperties.Attack, CardProperties);//no se puede generalizar?
        this.Heal = GetExpressionOrDefaultValueAsConstant(AllCardProperties.Heal, CardProperties);
        this.Defend = GetExpressionOrDefaultValueAsConstant(AllCardProperties.Defend, CardProperties);
        //llega la expresion sin () en extremos, despues de Trim

    }

    public static double CheckIfValueIsNumber(AllCardProperties property, Dictionary<AllCardProperties, string> CardProperties)
    {
        double value;
        if (!double.TryParse(CardProperties[property], out value))
        {
            throw new Exception("The healing powers value isn't a number.");
        }
        return value;
    }

    public IEvaluate GetExpressionOrDefaultValueAsConstant(AllCardProperties property, Dictionary<AllCardProperties, string> CardProperties)
    {
        if (!CardProperties.ContainsKey(property))
        {
            double defaultValue = Double.Parse(CardProperties[ExtraPropertiesDefaultValue[property]]);
            return new Constant(defaultValue);
        }
        return Interpreter.BuildExpression(CardProperties[property], this.Type);
        //return new TernaryExpression(CardProperties[property]);
    }
    public static Dictionary<AllCardProperties, AllCardProperties> SetValues()
    {
        Dictionary<AllCardProperties, AllCardProperties> dict = new Dictionary<AllCardProperties, AllCardProperties>();
        dict[AllCardProperties.Attack] = AllCardProperties.Damage;
        dict[AllCardProperties.Heal] = AllCardProperties.HealingPowers;
        dict[AllCardProperties.Defend] = AllCardProperties.Armour;
        return dict;
    }

}