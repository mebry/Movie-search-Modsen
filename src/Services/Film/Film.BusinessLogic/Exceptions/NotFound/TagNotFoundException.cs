namespace Film.BusinessLogic.Exceptions.NotFound
{
    /// <summary>
    /// Represents an exception that is thrown when an age restriction is not found.
    /// </summary>
    public class TagNotFoundException : NotFoundException
    {
        public TagNotFoundException(Guid id)
            : base($"Tag with id: {id} doesn't exist in the database.") { }
    }
}
