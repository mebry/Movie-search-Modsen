using System.ComponentModel.DataAnnotations;

namespace Rating.DataAccess.Entities
{
    public class RatingFilm
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid? FilmId { get; set; }
        public Film? Film { get; set; }

        [MinLength(1), MaxLength(10)]
        public int Score { get; set; }
    }
}
