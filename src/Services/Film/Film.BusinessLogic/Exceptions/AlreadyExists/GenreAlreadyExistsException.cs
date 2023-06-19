using Shared.Exceptions;

namespace Film.BusinessLogic.Exceptions.AlreadyExists
{
    /// <summary>
    /// Represents an exception that is thrown when an age restriction already exists.
    /// </summary>
    public class GenreAlreadyExistsException : AlreadyExistsException
    {
        public GenreAlreadyExistsException()
            : base("The Genre already exists") { }
    }
}
