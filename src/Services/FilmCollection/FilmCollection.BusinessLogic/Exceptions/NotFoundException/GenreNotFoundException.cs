using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmCollection.BusinessLogic.Exceptions.NotFoundException
{
    public class GenreNotFoundException : NotFoundException
    {
        public GenreNotFoundException(Guid genreId)
            : base($"Genre with ${genreId} doesn't exists")
        {
        }
    }
}
