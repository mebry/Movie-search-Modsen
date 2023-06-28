namespace Reporting.BusinessLogic.DTOs.ConsumerDTOs
{
    public class ConsumerFilmDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateOnly ReleaseDate { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
