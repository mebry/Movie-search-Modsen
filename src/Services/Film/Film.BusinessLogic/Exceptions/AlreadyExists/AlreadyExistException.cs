namespace Film.BusinessLogic.Exceptions.AlreadyExists
{
    public class AlreadyExistsException : Exception
    {
        public AlreadyExistsException(string message)
            : base(message) { }
    }
}
