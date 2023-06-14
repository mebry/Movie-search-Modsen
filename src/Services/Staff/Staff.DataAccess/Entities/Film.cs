namespace Staff.DataAccess.Entities
{
    public class Film
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public double AverageRating { get; set; }
        public int CountOfScores { get; set; }

        public ICollection<StaffPersonPosition> StaffPersonPositions { get; set; }
    }
}
