using FilmCollection.DataAccess.Models;
using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmCollection.DataAccess.Repositories.Interfaces
{
    public interface IFilmCountryRepository
    {
        Task CreateFilmCountryAsync(FilmCountry filmCountry);
        Task DeleteFilmCountryAsync(FilmCountry filmCountry);
        Task<FilmCountry> GetFilmCountryAsync(Countries countryId, Guid baseFilmInfoId, bool trackChanges);
    }
}
