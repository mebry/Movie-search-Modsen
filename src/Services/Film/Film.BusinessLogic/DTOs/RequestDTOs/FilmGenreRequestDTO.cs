namespace Film.BusinessLogic.DTOs.RequestDTOs
{
    /// <summary>
    /// Data transfer object for FilmGenre requests.
    /// </summary>
    public class FilmGenreRequestDTO
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
