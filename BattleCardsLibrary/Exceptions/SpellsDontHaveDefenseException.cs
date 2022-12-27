namespace BattleCardsLibrary.Exceptions
{
    public class SpellsDontHaveDefenseException : Exception
    {
        public SpellsDontHaveDefenseException() : base() { }

        public SpellsDontHaveDefenseException(string? message) : base(message) { }
    }
}
