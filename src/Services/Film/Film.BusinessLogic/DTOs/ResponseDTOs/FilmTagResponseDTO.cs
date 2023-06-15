using Shared.Enums;

namespace Film.BusinessLogic.DTOs.ResponseDTOs
{
    /// <summary>
    /// Data transfer object for FilmTag responses.
    /// </summary>
    public class FilmTagResponseDTO
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
