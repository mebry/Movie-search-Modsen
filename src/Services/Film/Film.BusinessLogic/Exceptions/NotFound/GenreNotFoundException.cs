namespace Film.BusinessLogic.Exceptions.NotFound
{
    public class GenreNotFoundException : NotFoundException
    {
        public GenreNotFoundException(Guid id)
            : base($"Genre with id: {id} doesn't exist in the database.") { }
    }
}
