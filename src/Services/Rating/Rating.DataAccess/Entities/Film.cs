using System.ComponentModel.DataAnnotations;

namespace Rating.DataAccess.Entities
{
    public class Film
    {
        public Guid Id { get; set; }

        [MinLength(1), MaxLength(10)]
        public double AverageRaiting { get; set; }

        [MinLength(0)]
        public int CountOfScores { get; set; }

        [MinLength(0)]
        public int OldCountOfScores { get; set; }
        public List<RatingFilm> RatingFilms { get; set; } = new();
    }
}
