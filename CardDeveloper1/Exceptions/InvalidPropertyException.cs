namespace CardDeveloper1.Exceptions
{
    public class InvalidPropertyException : Exception
    {
        public InvalidPropertyException() : base() { }

        public InvalidPropertyException(string? message) : base(message) { }
    }
}
