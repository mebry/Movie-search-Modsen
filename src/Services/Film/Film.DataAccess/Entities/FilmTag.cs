namespace Film.DataAccess.Entities
{
    /// <summary>
    /// Represents the relationship between a film and a tag.
    /// </summary>
    public class FilmTag
    {
        /// <summary>
        /// The unique identifier of the film.
        /// </summary>
        public Guid FilmId { get; set; }

        /// <summary>
        /// The film associated with this tag.
        /// </summary>
        public FilmModel Film { get; set; }

        /// <summary>
        /// The unique identifier of the tag.
        /// </summary>
        public Guid TagId { get; set; }

        /// <summary>
        /// The tag associated with this film.
        /// </summary>
        public Tag Tag { get; set; }
    }
}
