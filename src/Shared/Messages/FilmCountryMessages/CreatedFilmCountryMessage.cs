using Shared.Enums;

namespace Shared.Messages.FilmCountryMessages
{
    public class CreatedFilmCountryMessage
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
