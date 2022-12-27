using BattleCardsLibrary.PlayerNamespace;
using BattleCardsLibrary.Utils;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCardsLibrary
{
    public interface ICard
    {
        public string Description { get; set; }
        static Dictionary<AllCardProperties, AllCardProperties> ExtraPropertiesDefaultValue = SetValues();
        public double ManaCost { get; set; }
        public CardType Type { get; set; }
        public Player Owner { get; set; }
        public bool Used { get; set; }
        public string Name { get; set; }
        public double Damage { get; set; }
        public double HealingPowers { get; set; }
        public double HealthPoints { get;  set; }
        public double OnGameHealth { get; set; }
        public double Armour { get; set; }
        public IEvaluate Attack { get; set; }   //lo que se guarda aqui es una TernaryExpression que cuando se evalua devuelve double
        public IEvaluate Heal { get; set; }

        public static Dictionary<AllCardProperties, AllCardProperties> SetValues()
        {
            Dictionary<AllCardProperties, AllCardProperties> dict = new Dictionary<AllCardProperties, AllCardProperties>();
            dict[AllCardProperties.Attack] = AllCardProperties.Damage;
            dict[AllCardProperties.Heal] = AllCardProperties.HealingPowers;
            dict[AllCardProperties.Defend] = AllCardProperties.Armour;
            return dict;
        }
        public static string GetCardDescription(string[] cardDefinition)
        {
            string contentOfTxT = string.Empty;
            for (int i = 0; i < cardDefinition.Length; i++)
            {
                if (cardDefinition[i] == null)
                {
                    continue;
                }
                contentOfTxT += cardDefinition[i++] + ": " + cardDefinition[i] + "\r\n";
            }
            return contentOfTxT;
        }
    }
}
