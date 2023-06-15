namespace Film.BusinessLogic.Exceptions.NotFound
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message) { }
    }
}
