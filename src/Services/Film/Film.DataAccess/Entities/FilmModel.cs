namespace Film.DataAccess.Entities
{
    /// <summary>
    /// Represents a film.
    /// </summary>
    public class FilmModel
    {
        /// <summary>
        /// The unique identifier of the film.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The unique identifier of the age restriction for the film.
        /// </summary>
        public Guid AgeRestrictionId { get; set; }

        /// <summary>
        /// The age restriction associated with this film.
        /// </summary>
        public AgeRestriction AgeRestriction { get; set; }

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
        /// The average rating of the film.
        /// </summary>
        public double AverageRating { get; set; }

        /// <summary>
        /// The count of scores/ratings received by the film.
        /// </summary>
        public int CountScores { get; set; }

        /// <summary>
        /// The URL of the film's poster.
        /// </summary>
        public string PosterURL { get; set; } = string.Empty;

        /// <summary>
        /// The duration of the film.
        /// </summary>
        public TimeSpan Duration { get; set; }

        /// <summary>
        /// The list of countries associated with the film.
        /// </summary>
        public List<FilmCountry> FilmCountries { get; set; } = new();

        /// <summary>
        /// The list of genres associated with the film.
        /// </summary>
        public List<FilmGenre> FilmGenres { get; set; } = new();

        /// <summary>
        /// The list of tags associated with the film.
        /// </summary>
        public List<FilmTag> FilmTags { get; set; } = new();

        /// <summary>
        /// The list of staff person positions associated with the film.
        /// </summary>
        public List<StaffPersonPosition> StaffPersonPositions { get; set; } = new();
    }
}
