namespace Film.BusinessLogic.DTOs.RequestDTOs
{
    /// <summary>
    /// Data transfer object for FilmTag requests.
    /// </summary>
    public class FilmTagRequestDTO
    {
        /// <summary>
        /// The Id of the film.
        /// </summary>
        public Guid FilmId { get; set; }

        /// <summary>
        /// The Id of the tag.
        /// </summary>
        public Guid TagId { get; set; }
    }
}
