namespace Rating.BusinessLogic.DTOs
{
    public class ResponseRatingDTO
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid FilmId { get; set; }
        public int Score { get; set; }
    }
}
