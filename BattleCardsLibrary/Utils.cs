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
    public enum AllCardProperties
    {
        Attack,
        Heal,
        Defend,
        Type,
        Name,
        ManaCost,
        Damage,
        Armour,
        HealingPowers,
        HealthPoints,
        LifeTime,

    }

    public enum PlayerType
    {
        Human,
        RandomAI,
        GreedyAI
    }
    public enum Phase
    {
        MainPhase,
        BattlePhase
    }

    public enum ActionsByPlayer
    {
        DrawFromDeck,
        InvokeCard,
        Attack,
        Heal,
        TurnIsOver,
        DirectAttack,
        None

    }



}