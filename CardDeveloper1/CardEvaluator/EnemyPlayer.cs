using BattleCardsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardDeveloper1.CardEvaluator
{
    public class EnemyPlayer : IEvaluate
    {
        public string Property { get; set; }

        public EnemyPlayer(string property)
        {
            Property = property;
        }

        public double Evaluate(ICard onCard, ICard enemyCard)
        {
            switch (Property)
            {
                case "Health":
                    return enemyCard.Owner.Health;
                case "Mana":
                    return enemyCard.Owner.Mana;
                case "CardsOnBoard":
                    return onCard.Owner.CardsOnBoard.Count;
                case "CardsOnHand":
                    return onCard.Owner.Hand.Count;

                default:
                    throw new Exception("This isn't a player's property");//aqui nunca va a llegar

            }
        }
    }
}
