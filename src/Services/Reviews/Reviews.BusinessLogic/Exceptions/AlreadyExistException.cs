namespace Reviews.BusinessLogic.Exceptions
{
    public class AlreadyExistException : Exception
    {
        public AlreadyExistException(string message) : base(message) { }
    }
}
