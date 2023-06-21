using SharedExceptions = Shared.Exceptions;

namespace FilmCollection.BusinessLogic.Exceptions.AlreadyExistsException
{
    public class BaseFilmInfoAlreadyExistsException : SharedExceptions.AlreadyExistsException
    {
        public BaseFilmInfoAlreadyExistsException()
            :base("Such film already exists")
        { }
    }
}
