namespace BattleCardsLibrary.Exceptions
{
    public class NamelessCardException : Exception
    {
        public NamelessCardException() : base() { }

        public NamelessCardException(string? message) : base(message) { }
    }
}
