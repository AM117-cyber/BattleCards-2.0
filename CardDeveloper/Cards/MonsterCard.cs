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
    public void DefendFrom(ICard attackingCard, double attack)//solo los monstruos pueden ser atacados y por ende, solo ellos pueden defenderse
    {
        double defense = this.Defend.Evaluate(this, attackingCard);
        attack -= defense;
        if (attack < 0)
        {
            if (attackingCard.Type == CardType.Monster)
            {
                (attackingCard as IMonsterCard).SetOnGameHealth(0);
                attackingCard.Owner.CardsOnBoard.Remove(attackingCard);
            }
        }
        else
        {
            if (this.CurrentHealth <= attack)
            {
                double damageForPlayer = attack - this.CurrentHealth;
                this.Owner.SetHealth(this.Owner.Health - damageForPlayer);
                this.CurrentHealth = 0;
                this.Owner.CardsOnBoard.Remove(this);
                return;
            }
            this.CurrentHealth -= attack;
        }
       
    }
}