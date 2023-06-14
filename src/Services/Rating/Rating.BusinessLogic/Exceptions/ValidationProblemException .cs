namespace Rating.BusinessLogic.Exceptions
{
    public class ValidationProblemException : Exception
    {
        public ValidationProblemException(string message) : base(message)
        {
        }
    }
}
