namespace Film.BusinessLogic.Exceptions.NotFound
{
    /// <summary>
    /// Represents an exception that is thrown when an age restriction is not found.
    /// </summary>
    public class AgeRestrictionNotFoundException : NotFoundException
    {
        public AgeRestrictionNotFoundException(Guid id)
            : base($"Age restriction with id: {id} doesn't exist in the database.") { }
    }
}
