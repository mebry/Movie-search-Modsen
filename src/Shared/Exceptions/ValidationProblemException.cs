namespace Shared.Exceptions
{
    /// <summary>
    /// Represents an exception that occurs when there is a validation problem with the data.
    /// </summary>
    public class ValidationProblemException : Exception
    {
        public ValidationProblemException(string message) : base(message)
        {
        }
    }
}
