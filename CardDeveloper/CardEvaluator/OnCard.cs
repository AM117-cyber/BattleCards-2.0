using BattleCardsLibrary;
using BattleCardsLibrary.Utils;
using CardDeveloper.Utils;

namespace CardDeveloper.CardEvaluator
{
    public class OnCard : IEvaluable
    {
        public string Property { get; set; }
        public OnCard(string property, CardType type)
        {
            Property = property;
        }
        public double Evaluate(ICard onCard, ICard enemyCard)
        {
            switch (Property)
            {
                case "Damage":
                    return onCard.Damage;
                case "HealthPoints":
                    return onCard.CurrentHealth;
                case "ManaCost":
                    return onCard.ManaCost;
                case "LifeTime":
                    return (onCard as ISpellCard).LifeTime;
                case "Armour":
                    return onCard.Armour;
                case "HealingPowers":
                    return onCard.HealingPowers;
                default:
                    throw new Exception("The property chosen is incorrect.");
            }
        }
    }

}
