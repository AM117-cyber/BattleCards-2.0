using BattleCardsLibrary;
using BattleCardsLibrary.PlayerNamespace;
using BattleCardsLibrary.Utils;
using CardDeveloper.CardEvaluator;
using CardDeveloper.Exceptions;

namespace CardDeveloper.Cards;
public abstract class Card : ICard
{
    public string Description { get; }

    readonly Dictionary<AllCardProperties, AllCardProperties> ExtraPropertiesDefaultValue = SetValues();
    public double ManaCost { get; }
    public CardType Type { get; }
    public Player? Owner { get; set; }
    public bool Used { get; protected set; }
    public string Name { get;}
    public double Damage { get;}
    public double HealingPowers { get;}
    public double CurrentHealth { get; protected set; }
    public double Armour { get;}
    public IEvaluable Attack { get;}   //lo que se guarda aqui es una TernaryExpression que cuando se evalua devuelve double
    public IEvaluable Heal { get;}  //heal se pueden hacer separadas despues en dependencia de la prop, improve health seria heal por ejemplo
    
    protected double MaxHealth;
    //public string Deffend { get; set;}  // protected de algun tipo? no quiero que salga entre opciones de carta para jugador podria hacerse con if !=

    public Card(Dictionary<AllCardProperties, string> CardProperties, string[] description)
    {
        this.Type = CardProperties[AllCardProperties.Type] == "Monster" ? CardType.Monster : CardType.Spell;
        this.Name = CardProperties[AllCardProperties.Name];
        this.Owner = null;
        this.Used = false;
        this.ManaCost = CheckIfValueIsNumber(AllCardProperties.ManaCost, CardProperties);
        this.Damage = CheckIfValueIsNumber(AllCardProperties.Damage, CardProperties);
        this.HealingPowers = CheckIfValueIsNumber(AllCardProperties.HealingPowers, CardProperties);
        this.MaxHealth = CheckIfValueIsNumber(AllCardProperties.HealthPoints, CardProperties);
        CurrentHealth = MaxHealth;
        this.Armour = CheckIfValueIsNumber(AllCardProperties.Armour, CardProperties);
        this.Attack = GetExpressionOrDefaultValueAsConstant(AllCardProperties.Attack, CardProperties);//no se puede generalizar?
        this.Heal = GetExpressionOrDefaultValueAsConstant(AllCardProperties.Heal, CardProperties);
        this.Description = GetCardDescription(description);
        //llega la expresion sin () en extremos, despues de Trim

    }

    public void AttackCard(IMonsterCard enemyCard)//toda carta puede atacar
    {
        if (this.Used) return;
        double attack = this.Attack.Evaluate(this, enemyCard);
        double defenseResidue = enemyCard.DefendFrom(this, attack);
        if (this is IMonsterCard)
        {
            double health = (this as IMonsterCard).CurrentHealth + defenseResidue;
            if (health <= 0)
            {
                (this as MonsterCard).CurrentHealth = 0;
                this.Owner.CardsOnBoard.Remove(this);
            }
            else
            {
                (this as MonsterCard).CurrentHealth = health;
            }

        }
        this.SetUsed(true); 
    }
    
    public void DirectAttack(Player playerToAttack)
    {
        if (this.Used || !playerToAttack.NoMonstersOnBoard()) return;
        playerToAttack.Health -= this.Damage;
        this.SetUsed(true);
    }
    
    public void HealCard(IMonsterCard cardToHeal)
    {
        if (this.Used) return;
        double healingPoints = this.Heal.Evaluate(this, cardToHeal);
        cardToHeal.ReceiveHealing(healingPoints);
        this.SetUsed(true);
    }
    public void SetUsed(bool used)
    {
        this.Used = used;
    }

    protected static double CheckIfValueIsNumber(AllCardProperties property, Dictionary<AllCardProperties, string> CardProperties)
    {
        double value;
        if (!double.TryParse(CardProperties[property], out value))
        {
            throw new PropertyIsNotANumberException(property.ToString() + " value must be a number.");
        }
        return value;
    }

    protected IEvaluable GetExpressionOrDefaultValueAsConstant(AllCardProperties property, Dictionary<AllCardProperties, string> CardProperties)
    {
        if (!CardProperties.ContainsKey(property))
        {
            double defaultValue = double.Parse(CardProperties[ExtraPropertiesDefaultValue[property]]);
            return new Constant(defaultValue);
        }
        return Interpreter.BuildExpression(CardProperties[property], this.Type);
    }
    
    private static string GetCardDescription(string[] cardDefinition)
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

    private static Dictionary<AllCardProperties, AllCardProperties> SetValues()
    {
        Dictionary<AllCardProperties, AllCardProperties> dict = new()
        {
            [AllCardProperties.Attack] = AllCardProperties.Damage,
            [AllCardProperties.Heal] = AllCardProperties.HealingPowers,
            [AllCardProperties.Defend] = AllCardProperties.Armour
        };
        return dict;
    }

}