using BattleCardsLibrary.PlayerNamespace;
using BattleCardsLibrary.Utils;

namespace BattleCardsLibrary
{
    public interface ICard
    {
        public string Description { get; }
        public double ManaCost { get; }
        public Player? Owner { get; set; }
        public bool Used { get;}
        public string Name { get; }
        public double Damage { get; }
        public double HealingPowers { get; }
        public double CurrentHealth { get; }
        public double Armour { get;}
        public IEvaluable Attack { get; }   //lo que se guarda aqui es una TernaryExpression que cuando se evalua devuelve double
        public IEvaluable Heal { get; }
        public void AttackCard(IMonsterCard enemyCard);
        public void HealCard(IMonsterCard cardToHeal);
        public void DirectAttack(Player playerToAttack);
        public void MarkAsUnused();
    }
}
