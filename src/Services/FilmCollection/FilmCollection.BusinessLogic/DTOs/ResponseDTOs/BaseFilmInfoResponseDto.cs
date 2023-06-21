using Shared.Enums;

namespace FilmCollection.BusinessLogic.DTOs.ResponseDTOs
{
    public class BaseFilmInfoResponseDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string PosterURL { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public TimeSpan Duration { get; set; }
        public double AverageRating { get; set; }
        public int NumberOfRatings { get; set; }
        public IEnumerable<GenreResponseDto> Genres { get; set; }
        public IEnumerable<CountryResponseDto> Countries { get; set; }
    }
}
