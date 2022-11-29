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
    Owner,
    Name,
    TargetTypes,
    DamagePoints,
    Attack,
    Heal,
    Deffend,
 }
    
    
 


}