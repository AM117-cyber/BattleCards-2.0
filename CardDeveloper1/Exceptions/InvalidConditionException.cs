namespace CardDeveloper.Exceptions
{
    public class InvalidConditionException : Exception
    {
        public InvalidConditionException() : base() { }

        public InvalidConditionException(string? message) : base(message) { }
    }
}
