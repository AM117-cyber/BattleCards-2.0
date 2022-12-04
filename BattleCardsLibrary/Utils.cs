using System.Runtime.InteropServices.ComTypes;

namespace Utils;

public class Utils
{
public enum CardType
{
    Spell,
    Monster,
    Tool
}
    
public enum Operators
    {
        LowerThan,
        HigherThan,
        Equals,
        Different,

    }
public enum BasicCardProperties
 {
    ManaCost,
    Type,
    Name,
    TargetTypes,
    DamagePoints,
    Armour,
    HealingPowers,
    Attack,
    Heal,
    Deffend
 }

    public enum Phase
    {
        MainPhase,
        BattlePhase
    }
    
    
 


}