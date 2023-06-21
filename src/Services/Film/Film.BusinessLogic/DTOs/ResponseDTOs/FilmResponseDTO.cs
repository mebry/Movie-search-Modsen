namespace Film.BusinessLogic.DTOs.ResponseDTOs
{
    /// <summary>
    /// Data transfer object for Film responses.
    /// </summary>
    public class FilmResponseDTO
    {
        /// <summary>
        /// Gets or sets the ID of the film.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the age restriction for the film.
        /// </summary>
        public AgeRestrictionResponseDTO AgeRestriction { get; set; }

        /// <summary>
        /// Gets or sets the title of the film.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the description of the film.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the slogan of the film.
        /// </summary>
        public string Slogan { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the release date of the film.
        /// </summary>
        public DateOnly ReleaseDate { get; set; }

        /// <summary>
        /// Gets or sets the average rating of the film.
        /// </summary>
        public double AverageRating { get; set; }

        /// <summary>
        /// Gets or sets the count of scores for the film.
        /// </summary>
        public int CountScores { get; set; }

        /// <summary>
        /// Gets or sets the URL of the film's poster.
        /// </summary>
        public string PosterURL { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the duration of the film.
        /// </summary>
        public TimeSpan Duration { get; set; }

        /// <summary>
        /// The list of countries associated with the film.
        /// </summary>
        public List<CountryResponseDTO> Countries { get; set; } = new();

        /// <summary>
        /// The list of genres associated with the film.
        /// </summary>
        public List<GenreResponseDTO> Genres { get; set; } = new();

        /// <summary>
        /// The list of tags associated with the film.
        /// </summary>
        public List<TagResponseDTO> Tags { get; set; } = new();

        /// <summary>
        /// The list of staff person positions associated with the film.
        /// </summary>
        public List<StaffPersonResponseDTO> StaffPersons { get; set; } = new();
    }
}
