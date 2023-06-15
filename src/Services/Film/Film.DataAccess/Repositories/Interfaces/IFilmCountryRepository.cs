using Film.DataAccess.Entities;
using Shared.Enums;
using System.Diagnostics.Metrics;

namespace Film.DataAccess.Repositories.Interfaces
{
    /// <summary>
    /// Interface for a film country repository.
    /// </summary>
    public interface IFilmCountryRepository
    {
        /// <summary>
        /// Creates a new film country entity.
        /// </summary>
        /// <param name="filmCountry">The film country entity to create.</param>
        void Create(FilmCountry filmCountry);

        /// <summary>
        /// Deletes a film country by film ID and country.
        /// </summary>
        /// <param name="filmId">The ID of the film.</param>
        /// <param name="countryEnum">The country enum representing the film's country.</param>
        void Delete(Guid filmId, Countries countryEnum);

        /// <summary>
        /// Saves changes asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous save operation.</returns>
        Task SaveChangesAsync();
    }
}
