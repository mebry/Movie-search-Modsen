﻿namespace Staff.BusinessLogic.DTOs
{
    public class RequestFilmDTO
    {
        public string Title { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public double AverageRating { get; set; }
        public int CountOfScores { get; set; }
    }
}
