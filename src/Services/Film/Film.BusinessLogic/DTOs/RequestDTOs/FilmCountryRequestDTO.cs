using Shared.Enums;

namespace Film.BusinessLogic.DTOs.RequestDTOs
{
    /// <summary>
    /// Data transfer object for FilmCountry requests.
    /// </summary>
    public class FilmCountryRequestDTO
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
