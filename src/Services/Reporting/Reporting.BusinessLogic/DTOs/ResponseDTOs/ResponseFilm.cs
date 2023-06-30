namespace Reporting.BusinessLogic.DTOs.ResponseDTOs
{
    public class ResponseFilm
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateOnly ReleaseDate { get; set; }
        public TimeSpan Duration { get; set; }
        public double AverageRating { get; set; }
        public int CountOfScores { get; set; }
    }
}
