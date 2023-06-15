namespace Film.BusinessLogic.Exceptions.AlreadyExists
{
    public class GenreAlreadyExistsException : AlreadyExistsException
    {
        public GenreAlreadyExistsException()
            : base("The Genre already exists") { }
    }
}
