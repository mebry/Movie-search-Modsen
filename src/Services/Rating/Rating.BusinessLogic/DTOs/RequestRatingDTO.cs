namespace Rating.BusinessLogic.DTOs
{
    public class RequestRatingDTO
    {
        public Guid UserId { get; set; }
        public Guid FilmId { get; set; }
        public int Score { get; set; }
    }
}
