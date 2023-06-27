namespace Film.BusinessLogic.DTOs.ResponseDTOs
{
    /// <summary>
    /// Data transfer object for Position responses.
    /// </summary>
    public class PositionResponseDTO
    {
        /// <summary>
        /// The Id of the position.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The Name of the position.
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }
}
