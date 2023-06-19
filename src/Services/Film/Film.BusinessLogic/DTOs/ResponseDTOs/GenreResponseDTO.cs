namespace Film.BusinessLogic.DTOs.ResponseDTOs
{
    /// <summary>
    /// Data transfer object for Genre responses.
    /// </summary>
    public class GenreResponseDTO
    {
        /// <summary>
        /// The Id of the genre.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The Name of the genre.
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }
}
