using Shared.Exceptions;

namespace Film.BusinessLogic.Exceptions.NotFound
{
    /// <summary>
    /// Represents an exception that is thrown when an age restriction is not found.
    /// </summary>
    public class GenreNotFoundException : NotFoundException
    {
        public GenreNotFoundException(Guid id)
            : base($"Genre with id: {id} doesn't exist in the database.") { }
    }
}
