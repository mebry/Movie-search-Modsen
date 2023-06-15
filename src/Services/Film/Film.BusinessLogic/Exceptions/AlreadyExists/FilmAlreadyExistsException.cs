namespace Film.BusinessLogic.Exceptions.AlreadyExists
{
    public class FilmAlreadyExistsException: AlreadyExistsException
    {
        public FilmAlreadyExistsException()
            : base("The film already exists") { }
    }
}
