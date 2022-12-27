using BattleCardsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardDeveloper1.CardEvaluator
{
    public class OnPlayer : IEvaluate
    {
        public string Property { get; set; }

        public OnPlayer(string property)
        {
            Property = property;
        }

        public double Evaluate(ICard onCard, ICard enemyCard)
        {
            switch (Property)
            {
                case "Health":
                    return onCard.Owner.Health;
                case "Mana":
                    return onCard.Owner.Mana;
                case "CardsOnBoard":
                    return onCard.Owner.CardsOnBoard.Count;
                case "CardsOnHand":
                    return onCard.Owner.Hand.Count;

                default:
                    throw new Exception("This isn't a player's property");

            }
        }
    }
}
