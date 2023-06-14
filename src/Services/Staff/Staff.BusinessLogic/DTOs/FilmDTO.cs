namespace Staff.BusinessLogic.DTOs
{
    public class FilmDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateOnly ReleaseDate { get; set; }
        public double AverageRating { get; set; }
        public int CountOfScores { get; set; }
    }
}
