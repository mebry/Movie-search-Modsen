namespace Reporting.DataAccess.Entities
{
    public class Film
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateOnly ReleaseDate { get; set; }
        public TimeSpan Duration { get; set; }
        public double AverageRating { get; set; }
        public int CountOfScores { get; set; }
        public List<FilmCountry> FilmCountries { get; set; } = new();
        public List<FilmGenre> FilmGenres { get; set; } = new();
        public List<StaffPersonPosition> StaffPersonPositions { get; set; } = new();
        public List<Rating> Ratings { get; set; } = new();
    }
}
