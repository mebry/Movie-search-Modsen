using Shared.Enums;

namespace Shared.Messages.FilmCountryMessages
{
    public class RemovedFilmCountryMessage
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
