namespace Film.BusinessLogic.Exceptions.NotFound
{
    /// <summary>
    /// Represents an exception that is thrown when an age restriction is not found.
    /// </summary>
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message) { }
    }
}
