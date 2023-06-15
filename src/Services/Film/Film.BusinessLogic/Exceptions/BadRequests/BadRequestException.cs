namespace Film.BusinessLogic.Exceptions.BadRequests
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message)
        { }
    }
}
