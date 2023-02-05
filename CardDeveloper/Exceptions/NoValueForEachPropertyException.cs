namespace CardDeveloper.Exceptions
{
    public class NoValueForEachPropertyException : Exception
    {
        public NoValueForEachPropertyException() : base() { }

        public NoValueForEachPropertyException(string? message) : base(message) { }
    }
}
