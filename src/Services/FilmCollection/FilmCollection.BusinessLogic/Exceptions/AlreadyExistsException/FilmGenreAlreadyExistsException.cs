using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedExceptions = Shared.Exceptions;

namespace FilmCollection.BusinessLogic.Exceptions.AlreadyExistsException
{
    public class FilmGenreAlreadyExistsException : SharedExceptions.AlreadyExistsException
    {
        public FilmGenreAlreadyExistsException(Guid baseFilmInfoId, Guid genreId) 
            : base($"Base information about the film with {baseFilmInfoId} id already associated with genre with {genreId} id")
        {
        }
    }
}
