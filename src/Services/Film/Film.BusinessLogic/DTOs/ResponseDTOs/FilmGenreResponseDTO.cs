using Shared.Enums;

namespace Film.BusinessLogic.DTOs.ResponseDTOs
{
    /// <summary>
    /// Data transfer object for FilmGenre responses.
    /// </summary>
    public class FilmGenreResponseDTO
    {
        /// <summary>
        /// The Id of the film.
        /// </summary>
        public Guid FilmId { get; set; }

        /// <summary>
        /// The Id of the genre.
        /// </summary>
        public Guid GenreId { get; set; }
    }
}
