namespace Reporting.BusinessLogic.DTOs.ResponseDTOs
{
    public class ResponseDistributionByGenre
    {
        public ResponseGenre? ResponseGenre { get; set; }
        public int CountOfFilms { get; set; }
        public double AverageRating { get; set; }
    }
}
