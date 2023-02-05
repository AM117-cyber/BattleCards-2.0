using BattleCardsLibrary;
using BattleCardsLibrary.Utils;

namespace CardDeveloper.Cards;
public class MonsterCard : Card, IMonsterCard
{
    public IEvaluable Defend { get; }

    public MonsterCard(Dictionary<AllCardProperties, string> CardProperties, string[] description) : base(CardProperties, description)
    {

        this.Defend = GetExpressionOrDefaultValueAsConstant(AllCardProperties.Defend, CardProperties);
    }


    public void SetOnGameHealth(double health)
    {
        if (health < this.MaxHealth)
        {
            this.CurrentHealth = health;
        }
        else
        {
            this.CurrentHealth = this.MaxHealth;
        }
    }
    public bool NeedsHealing()
    {
        if (this.CurrentHealth < this.MaxHealth)
        {
            return true;
        }
        return false;
    }
    
    public void ReceiveHealing(double healingPoints)
    {
        this.CurrentHealth += healingPoints;
    }
    public double DefendFrom(ICard attackingCard, double attack)//solo los monstruos pueden ser atacados y por ende, solo ellos pueden defenderse
    {
        
        double defense = this.Defend.Evaluate(this, attackingCard);
        attack -= defense;
        if (attack < 0)
        {
            return attack;
        }
        else
        {
            if (this.CurrentHealth <= attack)
            {
                double damageForPlayer = attack - this.CurrentHealth;
                this.Owner.Health -= damageForPlayer;
                this.CurrentHealth = 0;
                this.Owner.CardsOnBoard.Remove(this);
                
            }
            this.CurrentHealth -= attack;
        }
        return 0;
    }
}