namespace Reviews.BusinessLogic.DTOs
{
    public class RequestReviewDTO
    {
        public Guid CriticId { get; set; }
        public Guid TypeOfReviewId { get; set; }
        public Guid FilmId { get; set; }
        public DateTime DateTimeOfCreation { get; set; }
        public string Title { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
    }
}
