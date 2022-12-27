namespace BattleCardsLibrary.Exceptions
{
    public class PropertyIsNotANumberException : Exception
    {
        public PropertyIsNotANumberException() : base() { }

        public PropertyIsNotANumberException(string? message) : base(message) { }
    }
}
