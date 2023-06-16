namespace Film.BusinessLogic.Exceptions.AlreadyExists
{
    /// <summary>
    /// Represents an exception that is thrown when an age restriction already exists.
    /// </summary>
    public class FilmAlreadyExistsException: AlreadyExistsException
    {
        public FilmAlreadyExistsException()
            : base("The film already exists") { }
    }
}
