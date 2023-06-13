using System.ComponentModel.DataAnnotations;

namespace Rating.DataAccess.Entities
{
    public class Raiting
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? FilmId { get; set; }
        public Film? Film { get; set; }

        [MinLength(1), MaxLength(10)]
        public int Score { get; set; }
    }
}
