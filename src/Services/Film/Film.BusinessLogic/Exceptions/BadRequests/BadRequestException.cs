namespace Film.BusinessLogic.Exceptions.BadRequests
{
    /// <summary>
    /// Represents an exception that is thrown when a bad request is encountered.
    /// </summary>
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message)
        { }
    }
}
