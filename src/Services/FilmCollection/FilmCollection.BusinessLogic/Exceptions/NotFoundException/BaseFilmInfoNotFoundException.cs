using SharedExceptions = Shared.Exceptions;

namespace FilmCollection.BusinessLogic.Exceptions.NotFoundException
{
    public class BaseFilmInfoNotFoundException : SharedExceptions.NotFoundException
    {
        public BaseFilmInfoNotFoundException(Guid id)
            :base($"Information about film with ${id} id doesn't exists")
        {
            
        }
    }
}
