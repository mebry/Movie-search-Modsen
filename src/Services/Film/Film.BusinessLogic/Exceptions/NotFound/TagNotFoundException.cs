namespace Film.BusinessLogic.Exceptions.NotFound
{
    public class TagNotFoundException : NotFoundException
    {
        public TagNotFoundException(Guid id)
            : base($"Tag with id: {id} doesn't exist in the database.") { }
    }
}
