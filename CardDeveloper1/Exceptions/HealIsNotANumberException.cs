namespace CardDeveloper1.Exceptions
{
    public class PropertyIsNotANumberException : Exception
    {
        public PropertyIsNotANumberException() : base() { }

        public PropertyIsNotANumberException(string? message) : base(message) { }
    }
}
