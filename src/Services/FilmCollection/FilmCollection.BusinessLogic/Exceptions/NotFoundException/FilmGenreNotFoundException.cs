using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmCollection.BusinessLogic.Exceptions.NotFoundException
{
    public class FilmGenreNotFoundException : NotFoundException
    {
        public FilmGenreNotFoundException(Guid genreId, Guid baseFilmInfoId) 
            : base($"The association between base film info with ${baseFilmInfoId} and genre with ${genreId} doesn't exists")
        {
        }
    }
}
