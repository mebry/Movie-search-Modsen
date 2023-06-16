namespace Film.DataAccess.Entities
{
    /// <summary>
    /// Represents the relationship between a film and its genre.
    /// </summary>
    public class FilmGenre
    {
        /// <summary>
        /// The unique identifier of the film.
        /// </summary>
        public Guid FilmId { get; set; }

        /// <summary>
        /// The film associated with this genre.
        /// </summary>
        public FilmModel Film { get; set; }

        /// <summary>
        /// The unique identifier of the genre.
        /// </summary>
        public Guid GenreId { get; set; }

        /// <summary>
        /// The genre associated with this film.
        /// </summary>
        public Genre Genre { get; set; }
    }
}
