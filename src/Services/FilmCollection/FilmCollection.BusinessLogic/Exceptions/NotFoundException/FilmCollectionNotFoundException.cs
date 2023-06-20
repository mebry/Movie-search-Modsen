using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedExceptions = Shared.Exceptions;

namespace FilmCollection.BusinessLogic.Exceptions.NotFoundException
{
    public class FilmCollectionNotFoundException : SharedExceptions.NotFoundException
    {
        public FilmCollectionNotFoundException(Guid collectionId, Guid baseFilmInfoId)
            : base($"The association between base film info with ${baseFilmInfoId} and collection with ${collectionId} doesn't exists")
        {

        }
    }
}
