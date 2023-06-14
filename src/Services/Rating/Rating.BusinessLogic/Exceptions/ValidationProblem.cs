namespace Rating.BusinessLogic.Exceptions
{
    public class ValidationProblem : Exception
    {
        public ValidationProblem(string message) : base(message)
        {
        }
    }
}
