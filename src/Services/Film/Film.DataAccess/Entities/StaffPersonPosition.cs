namespace Film.DataAccess.Entities
{
    /// <summary>
    /// Represents a staff person's position in a film.
    /// </summary>
    public class StaffPersonPosition
    {
        /// <summary>
        /// The unique identifier of the staff person.
        /// </summary>
        public Guid StaffPersonId { get; set; }

        /// <summary>
        /// The staff person associated with this position.
        /// </summary>
        public StaffPerson StaffPerson { get; set; }

        /// <summary>
        /// The unique identifier of the position.
        /// </summary>
        public Guid PositionId { get; set; }

        /// <summary>
        /// The position associated with this staff person.
        /// </summary>
        public Position Position { get; set; }

        /// <summary>
        /// The unique identifier of the film.
        /// </summary>
        public Guid FilmId { get; set; }

        /// <summary>
        /// The film associated with this staff person position.
        /// </summary>
        public FilmModel Film { get; set; }
    }
}
