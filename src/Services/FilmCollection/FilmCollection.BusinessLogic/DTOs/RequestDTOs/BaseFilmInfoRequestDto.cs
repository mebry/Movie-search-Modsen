﻿namespace FilmCollection.BusinessLogic.DTOs.RequestDTOs
{
    public class BaseFilmInfoRequestDto
    {
        public string Title { get; set; }
        public string PosterURL { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public TimeSpan Duration { get; set; }
        public double AverageRating { get; set; }
        public int NumberOfRatings { get; set; }
    }
}
