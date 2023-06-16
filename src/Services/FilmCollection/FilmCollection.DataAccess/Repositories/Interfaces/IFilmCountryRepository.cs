using FilmCollection.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmCollection.DataAccess.Repositories.Interfaces
{
    public interface IFilmCountryRepository
    {
        void CreateFilmCountry(FilmCountry filmCountry);
        void DeleteFilmCountry(FilmCountry filmCountry);
    }
}
