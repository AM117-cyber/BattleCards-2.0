namespace CardDeveloper.Exceptions
{
    public class InvalidOperatorException : Exception
    {
        public InvalidOperatorException() : base() { }

        public InvalidOperatorException(string? message) : base(message) { }
    }
}
