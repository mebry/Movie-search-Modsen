using SharedExceptions = Shared.Exceptions;

namespace FilmCollection.BusinessLogic.Exceptions.AlreadyExistsException
{
    internal class CollectionAlreadyExistsException : SharedExceptions.AlreadyExistsException
    {
        public CollectionAlreadyExistsException() 
            : base("Such collection already exists")
        {
        }
    }
}
