using Film.BusinessLogic.DTOs.RequestDTOs;
using Film.BusinessLogic.DTOs.ResponseDTOs;
using Shared.Enums;

namespace Film.BusinessLogic.Services.Interfaces
{
    /// <summary>
    /// Service interface for film countries.
    /// </summary>
    public interface IFilmCountryService
    {
        /// <summary>
        /// Creates a new film country.
        /// </summary>
        /// <param name="filmCountry">The film country data.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task CreateAsync(FilmCountryRequestDTO filmCountry);

        /// <summary>
        /// Deletes a film country.
        /// </summary>
        /// <param name="filmId">The ID of the film.</param>
        /// <param name="countryId">The country enumeration value.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task DeleteAsync(Guid filmId, Countries countryId);
    }
}
