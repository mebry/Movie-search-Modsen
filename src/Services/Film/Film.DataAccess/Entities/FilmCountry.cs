using Shared.Enums;

namespace Film.DataAccess.Entities
{
    /// <summary>
    /// Represents the relationship between a film and a country.
    /// </summary>
    public class FilmCountry
    {
        /// <summary>
        /// The unique identifier of the film.
        /// </summary>
        public Guid FilmId { get; set; }

        /// <summary>
        /// The film associated with this country.
        /// </summary>
        public FilmModel Film { get; set; }

        /// <summary>
        /// The country associated with this film.
        /// </summary>
        public Countries CountryId { get; set; }
    }
}
