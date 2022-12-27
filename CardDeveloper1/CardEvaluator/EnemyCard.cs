using BattleCardsLibrary;
using CardDeveloper1.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardDeveloper1.CardEvaluator
{
    public class EnemyCard : IEvaluate
    {
        public string Property { get; set; }
        public EnemyCard(string property)
        {
            Property = property;
        }
        public double Evaluate(ICard onCard, ICard enemyCard)
        {
            switch (Property)
            {
                case "Damage":
                    return enemyCard.Damage;
                case "HealthPoints":
                    return enemyCard.OnGameHealth;
                case "ManaCost":
                    return enemyCard.ManaCost;
                case "Armour":
                    return enemyCard.Armour;
                case "HealingPowers":
                    return enemyCard.HealingPowers;
                default:
                    throw new InvalidPropertyException("The property chosen in incorrect.");//aqui nunca llega
            }
        }
    }
}
