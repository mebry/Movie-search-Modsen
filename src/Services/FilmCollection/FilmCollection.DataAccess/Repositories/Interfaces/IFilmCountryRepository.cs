using FilmCollection.DataAccess.Models;
using Shared.Enums;

namespace FilmCollection.DataAccess.Repositories.Interfaces
{
    public interface IFilmCountryRepository
    {
        Task CreateFilmCountryAsync(FilmCountry filmCountry);
        Task DeleteFilmCountryAsync(FilmCountry filmCountry);
        Task<FilmCountry> GetFilmCountryAsync(Countries countryId, Guid baseFilmInfoId, bool trackChanges);
    }
}
