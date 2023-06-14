namespace Film.DataAccess.Entities
{
    public class Film
    {
        public Guid Id { get; set; }

        public Guid AgeRestrictionId { get; set; }

        public AgeRestriction AgeRestriction { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Slogan { get; set; } = string.Empty;

        public DateOnly ReleaseDate { get; set; }

        public double AverageRating { get; set; }

        public int CountOfScores { get; set; }

        public string PosterURL { get; set; } = string.Empty;

        public TimeSpan Duration { get; set; }

        public List<FilmCountry> FilmCountries { get; set; } = new();
        public List<FilmGenre> FilmGenres { get; set; } = new();
        public List<FilmTag> FilmTags { get; set; } = new();
        public List<StaffPersonPosition> StaffPersonPositions { get; set; } = new();
    }
}
