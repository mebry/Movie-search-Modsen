﻿namespace Rating.DataAccess.Entities
{
    public class RatingFilm
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid? FilmId { get; set; }
        public Film? Film { get; set; }
        public int Score { get; set; }
    }
}
