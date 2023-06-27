namespace Film.BusinessLogic.DTOs.RequestDTOs
{
    /// <summary>
    /// Data transfer object for Film requests.
    /// </summary>
    public class FilmRequestDTO
    {
        /// <summary>
        /// The Id of the age restriction.
        /// </summary>
        public Guid AgeRestrictionId { get; set; }

        /// <summary>
        /// The title of the film.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// The description of the film.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// The slogan of the film.
        /// </summary>
        public string Slogan { get; set; } = string.Empty;

        /// <summary>
        /// The release date of the film.
        /// </summary>
        public DateOnly ReleaseDate { get; set; }

        /// <summary>
        /// The URL of the film's poster.
        /// </summary>
        public string PosterURL { get; set; } = string.Empty;

        /// <summary>
        /// The duration of the film.
        /// </summary>
        public TimeSpan Duration { get; set; }
    }
}
