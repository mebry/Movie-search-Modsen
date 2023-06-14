namespace Film.DataAccess.Entities
{
    /// <summary>
    /// Represents a position of a staff person in a film.
    /// </summary>
    public class Position
    {
        /// <summary>
        /// The unique identifier of the position.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The name of the position.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The list of staff person positions associated with this position.
        /// </summary>
        public List<StaffPersonPosition> StaffPersonPositions { get; set; } = new();
    }
}
