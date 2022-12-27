namespace CardDeveloper1.Exceptions
{
    public class InvalidCardTypeException : Exception
    {
        public InvalidCardTypeException() : base() {}

        public InvalidCardTypeException(string? message) : base(message) {}
    }
}
