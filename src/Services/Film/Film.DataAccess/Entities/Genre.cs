namespace Film.DataAccess.Entities
{
    /// <summary>
    /// Represents a genre of films.
    /// </summary>
    public class Genre
    {
        /// <summary>
        /// The unique identifier of the genre.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The name of the genre.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The list of film genres associated with this genre.
        /// </summary>
        public List<FilmGenre> FilmGenres { get; set; } = new();
    }
}
