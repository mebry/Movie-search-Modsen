using SharedExceptions = Shared.Exceptions;

namespace FilmCollection.BusinessLogic.Exceptions.AlreadyExistsException
{
    public class GenreAlreadyExistsException : SharedExceptions.AlreadyExistsException
    {
        public GenreAlreadyExistsException() 
            : base("This genre already exists") { }
    }
}
