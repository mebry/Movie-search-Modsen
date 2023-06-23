namespace Shared.Messages.FilmMessages
{
    public class CreatedFilmMessage
    {
        /// <summary>
        /// Gets or sets the Id of the film.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the title of the film.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the description of the film.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the release date of the film.
        /// </summary>
        public DateOnly ReleaseDate { get; set; }

        /// <summary>
        /// Gets or sets the URL of the film's poster.
        /// </summary>
        public string PosterURL { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the duration of the film.
        /// </summary>
        public TimeSpan Duration { get; set; }
    }
}
