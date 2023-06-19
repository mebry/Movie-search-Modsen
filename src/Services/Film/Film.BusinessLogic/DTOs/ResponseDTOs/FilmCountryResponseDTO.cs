using Shared.Enums;

namespace Film.BusinessLogic.DTOs.ResponseDTOs
{
    /// <summary>
    /// Data transfer object for FilmCountry responses.
    /// </summary>
    public class FilmCountryResponseDTO
    {
        /// <summary>
        /// The Id of the film.
        /// </summary>
        public Guid FilmId { get; set; }

        /// <summary>
        /// The Id of the country.
        /// </summary>
        public Countries CountryId { get; set; }
    }
}
