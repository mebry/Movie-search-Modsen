namespace Film.BusinessLogic.DTOs.ResponseDTOs
{
    /// <summary>
    /// Data transfer object for Tag responses.
    /// </summary>
    public class TagResponseDTO
    {
        /// <summary>
        /// The Id of the tag.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The Name of the tag.
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }
}
