using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedExceptions = Shared.Exceptions;

namespace FilmCollection.BusinessLogic.Exceptions.AlreadyExistsException
{
    public class FilmCollectionAlreadyExistsException : SharedExceptions.AlreadyExistsException
    {
        public FilmCollectionAlreadyExistsException(Guid collectionId, Guid baseFilmInfoId) 
            : base($"Base information about the film with ${baseFilmInfoId} id already exists in the collection with ${collectionId} id") { }
    }
}
