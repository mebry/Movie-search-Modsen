namespace FilmCollection.DataAccess.Repositories.Interfaces
{
    public interface IFilmCollectionRepository
    {
        Task CreateFilmCollectionAsync(FilmCollection.DataAccess.Models.FilmCollection filmCollection);
        Task DeleteFilmCollectionAsync(FilmCollection.DataAccess.Models.FilmCollection filmCollection);
        Task<Models.FilmCollection> GetFilmCollectionAsync(Guid collectionId, Guid filmBaseInfoId, bool trackChanges);
    }
}
