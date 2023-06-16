using FilmCollection.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmCollection.DataAccess.Repositories.Interfaces
{
    public interface IFilmCollectionRepository
    {
        void CreateFilmCollection(FilmCollection.DataAccess.Models.FilmCollection filmCollection);
        void DeleteFilmCollection(FilmCollection.DataAccess.Models.FilmCollection filmCollection);
    }
}
