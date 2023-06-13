namespace Rating.BusinessLogic.DTOs
{
    public class RatingDTO
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid FilmId { get; set; }
        public int Score { get; set; }
    }
}
