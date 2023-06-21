namespace Film.BusinessLogic.DTOs.ResponseDTOs
{
    /// <summary>
    /// Data transfer object for country responses.
    /// </summary>
    public class CountryResponseDTO
    {
        /// <summary>
        /// The Id of the country.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The Name of the country.
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }
}
