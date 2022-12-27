using BattleCardsLibrary;
using CardDeveloper1.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleCardsLibrary.Utils;

namespace CardDeveloper1.CardEvaluator
{
    public class OnCard : IEvaluate
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
                    return onCard.OnGameHealth;
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
