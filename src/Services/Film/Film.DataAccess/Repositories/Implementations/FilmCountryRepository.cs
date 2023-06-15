using Film.DataAccess.Contexts;
using Film.DataAccess.Entities;
using Film.DataAccess.Repositories.Interfaces;
using Shared.Enums;

namespace Film.DataAccess.Repositories.Implementations
{
    /// <summary>
    /// Repository for managing film country entities.
    /// </summary>
    public class FilmCountryRepository : IFilmCountryRepository
    {
        private readonly FilmContext _context;

        public FilmCountryRepository(FilmContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Creates a new film country entity.
        /// </summary>
        /// <param name="filmCountry">The film country entity to create.</param>
        public void Create(FilmCountry filmCountry)
        {
            _context.FilmCountries.Add(filmCountry);
        }

        /// <summary>
        /// Deletes a film country entity.
        /// </summary>
        /// <param name="filmId">The ID of the film.</param>
        /// <param name="countryEnum">The country of the film.</param>
        public void Delete(Guid filmId, Countries countryEnum)
        {
            var filmCountry = _context.FilmCountries.FirstOrDefault(fc => fc.FilmId == filmId && fc.CountryId == countryEnum);
            if (filmCountry != null)
            {
                _context.FilmCountries.Remove(filmCountry);
            }
        }

        /// <summary>
        /// Saves the changes made to the repository asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous save operation.</returns>
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
