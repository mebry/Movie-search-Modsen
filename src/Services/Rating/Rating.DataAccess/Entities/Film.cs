using System.ComponentModel.DataAnnotations;

namespace Rating.DataAccess.Entities
{
    public class Film
    {
        public Guid Id { get; set; }

        [MinLength(1, ErrorMessage = "Name cannot be less than 1")]
        [MaxLength(10, ErrorMessage = "Name cannot be greater than 10")]
        public double AverageRaiting { get; set; }
        public uint CountOfScores { get; set; }
        public uint LastSendCountOfScores { get; set; }
        public DateTime LastMessageWasSent { get; set; } = new();
        public List<RatingFilm> RatingFilms { get; set; } = new();
    }
}
