namespace BattleCardsLibrary.Exceptions
{
    public class InvalidPropertyException : Exception
    {
        public InvalidPropertyException() : base() { }

        public InvalidPropertyException(string? message) : base(message) { }
    }
}
