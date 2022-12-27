using BattleCardsLibrary.Cards;
using BattleCardsLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleCardsLibrary.Utils;

namespace BattleCardsLibrary.Cards.CardEvaluator
{
    public class OnCard : IEvaluate
    {
        public string Property { get; set; }
        public OnCard(string property, CardType type)
        {
            Property = property;
        }
        public double Evaluate(Card onCard, Card enemyCard)
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
                    return (onCard as SpellCard).LifeTime;
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
