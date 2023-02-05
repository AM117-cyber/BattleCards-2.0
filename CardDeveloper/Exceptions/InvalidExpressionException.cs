namespace CardDeveloper.Exceptions
{
    public class InvalidExpressionException : Exception
    {
        public InvalidExpressionException() : base() { }

        public InvalidExpressionException(string? message) : base(message) { }
    }
}
