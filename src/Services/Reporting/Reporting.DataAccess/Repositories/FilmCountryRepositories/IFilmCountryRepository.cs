using Reporting.DataAccess.Entities;
using Shared.Enums;

namespace Reporting.DataAccess.Repositories.FilmCountryRepositories
{
    public interface IFilmCountryRepository
    {
        public void Create(FilmCountry filmCountry);
        public void Delete(Guid filmId, Countries countryEnum);

        /// <summary>
        /// Saves changes asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous save operation.</returns>
        public Task SaveChangesAsync();
    }
}
