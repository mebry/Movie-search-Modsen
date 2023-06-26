namespace Shared.Messages.FilmCountryMessages
{
    public class CreatedFilmGenreMessage
    {
        /// <summary>
        /// The Id of the film.
        /// </summary>
        public Guid FilmId { get; set; }

        /// <summary>
        /// The Id of the genre.
        /// </summary>
        public Guid GenreId { get; set; }
    }
}
