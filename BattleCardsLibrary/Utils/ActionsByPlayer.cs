using System.Runtime.InteropServices.ComTypes;

namespace BattleCardsLibrary.Utils;

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