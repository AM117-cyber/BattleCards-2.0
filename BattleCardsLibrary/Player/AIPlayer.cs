
using BattleCardsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleCardsLibrary.Utils;

namespace BattleCardsLibrary.PlayerNamespace
{
    public class AIPlayer : Player, IVirtualPlay
    {
        private Player player;
        private ICard cardToInvokeAndActivate = null;
        private IMonsterCard targetCard = null;
        private ActionsByPlayer effect = ActionsByPlayer.TurnIsOver;
        public AIPlayer(string name, List<ICard> deck, int n) : base(name, deck, n)
        {
            Type = PlayerType.GreedyAI;
        }

        public void Play()//pasa por todas las jugadas validas y envia la mejor
        {
            if (player == null)
            {
                player = Game.GetCurrentPlayer();
            }

            if (Game.CurrentPhase == Phase.MainPhase)
            {//MainPhase actions
                cardToInvokeAndActivate = null;
                targetCard = null;
                //first you invoke
                if (player.Hand.Count != 0)
                {
                    (cardToInvokeAndActivate, targetCard, effect) = GetCardToInvoke();
                    Game.CardActionReceiver(ActionsByPlayer.InvokeCard, cardToInvokeAndActivate, null, 1);
                }

                //then you draw from deck if you can
                if (Hand.Count < 5 && Mana >= 1)
                {
                    Game.CardActionReceiver(ActionsByPlayer.DrawFromDeck, null, null, player.Number);
                }
                Game.CardActionReceiver(ActionsByPlayer.TurnIsOver, null, null, 1);
                return;
            }
            if (Game.CurrentPhase == Phase.BattlePhase)
            {
                //BattlePhase actions
                if (effect != ActionsByPlayer.TurnIsOver)
                {
                    Game.CardActionReceiver(effect, cardToInvokeAndActivate, targetCard, 1);
                    effect = ActionsByPlayer.TurnIsOver;
                    cardToInvokeAndActivate = null;
                    targetCard = null;
                    return;
                }

                List<IMonsterCard> enemyPlayersMonsters = GetMonsterCardsOnBoard(Number == 1 ? Game.Player2.CardsOnBoard : Game.Player1.CardsOnBoard);
                for (int i = 0; i < CardsOnBoard.Count; i++)
                {
                    if (i < enemyPlayersMonsters.Count && CardsOnBoard[i].Damage != 0)
                    {
                        Game.CardActionReceiver(ActionsByPlayer.Attack, CardsOnBoard[i], enemyPlayersMonsters[i], 1);

                    }
                    else
                    {
                        if (CardsOnBoard[i].HealingPowers != 0)
                        {
                            Game.CardActionReceiver(ActionsByPlayer.Heal, CardsOnBoard[i], YouNeedAHealerCard().Item1, 1);
                            continue;
                        }
                        Game.CardActionReceiver(ActionsByPlayer.DirectAttack, CardsOnBoard[i], null, 1);
                    }

                }
                Game.CardActionReceiver(ActionsByPlayer.TurnIsOver, null, null, 1);
            }
        }

        public (ICard, IMonsterCard, ActionsByPlayer) GetCardToInvoke()
        {
            ICard cardToInvoke = null;
            double valueOfEffect = 0;
            (IMonsterCard card, bool IsTrue) needAHealerCard = YouNeedAHealerCard();
            if (needAHealerCard.IsTrue)
            {
                foreach (ICard card in Hand)
                {
                    if (card.ManaCost <= Mana)
                    {
                        double actualHealing = card.Heal.Evaluate(card, needAHealerCard.card);
                        if (actualHealing > valueOfEffect)
                        {
                            valueOfEffect = actualHealing;
                            cardToInvoke = card;
                        }
                    }
                }
                if (valueOfEffect != 0)
                {
                    return (cardToInvoke, needAHealerCard.card, ActionsByPlayer.Heal);
                }//if you get here you coudn't invoke a spellcard
            }
            IMonsterCard victimCard = null;
            List<IMonsterCard> monstersOnEnemysSide = GetMonsterCardsOnBoard(Number == 1 ? Game.Player2.CardsOnBoard : Game.Player1.CardsOnBoard);
            foreach (ICard myCard in Hand)
            {
                if (myCard.ManaCost <= Mana && (myCard.Damage != 0 || myCard.Attack.Evaluate(myCard, myCard as IMonsterCard) != 0))
                {//Card is invokable
                    foreach (IMonsterCard enemyCard in monstersOnEnemysSide)
                    {
                        double actualAttacking = myCard.Attack.Evaluate(myCard, enemyCard);
                        if (actualAttacking > valueOfEffect)
                        {
                            valueOfEffect = actualAttacking;
                            cardToInvoke = myCard;
                            victimCard = enemyCard;
                        }
                    }
                    if (monstersOnEnemysSide.Count == 0)
                    {
                        return (myCard, null, ActionsByPlayer.DirectAttack);
                    }

                }
            }
            return (cardToInvoke, victimCard, ActionsByPlayer.Attack);



        }

        public List<IMonsterCard> GetMonsterCardsOnBoard(List<ICard> enemysCards)
        {
            List<IMonsterCard> answer = new List<IMonsterCard>();
            foreach (var card in enemysCards)
            {
                if (card.Type == CardType.Monster)
                {
                    answer.Add((IMonsterCard)card);
                }
            }
            return answer;
        }

        public (IMonsterCard, bool) YouNeedAHealerCard()
        {
            List<IMonsterCard> myMonsters = GetMonsterCardsOnBoard(CardsOnBoard);
            foreach (IMonsterCard monster in myMonsters)
            {
                if (monster.OnGameHealth < monster.HealthPoints)
                {
                    return (monster, true);
                }
            }
            return (null, false);
        }
    }
}
