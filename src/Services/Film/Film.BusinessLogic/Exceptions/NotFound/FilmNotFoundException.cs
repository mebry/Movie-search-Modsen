namespace Film.BusinessLogic.Exceptions.NotFound
{
    public class FilmNotFoundException : NotFoundException
    {
        public FilmNotFoundException(Guid id)
            : base($"Film with id: {id} doesn't exist in the database.") { }
    }
}
