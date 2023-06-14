namespace Film.DataAccess.Entities
{
    /// <summary>
    /// Represents a staff person involved in the making of a film.
    /// </summary>
    public class StaffPerson
    {
        /// <summary>
        /// The unique identifier of the staff person.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The name of the staff person.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The surname of the staff person.
        /// </summary>
        public string Surname { get; set; } = string.Empty;

        /// <summary>
        /// The URL of the staff person's image.
        /// </summary>
        public string ImageUrl { get; set; } = string.Empty;

        /// <summary>
        /// The list of staff person positions associated with this staff person.
        /// </summary>
        public List<StaffPersonPosition> StaffPersonPositions { get; set; } = new();
    }
}
