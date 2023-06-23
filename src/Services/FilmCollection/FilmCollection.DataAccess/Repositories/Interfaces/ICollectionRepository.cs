using FilmCollection.DataAccess.Models;

namespace FilmCollection.DataAccess.Repositories.Interfaces
{
    public interface ICollectionRepository
    {
        Task CreateCollectionAsync(CollectionModel collection);
        Task DeleteCollectionAsync(CollectionModel collection);
        Task UpdateCollectionAsync(CollectionModel collection);
        Task<IEnumerable<CollectionModel>> GetAllCollectionsAsync(bool trackChanges);
        Task<CollectionModel> GetCollectionAsync(Guid id, bool trackChanges);
        Task<CollectionModel> GetCollectionByTitleAndDescriptionAsync(string title, string description, bool trackChanges);
        Task<CollectionModel> GetCollectionByTitleAsync(string title, bool trackChanges);
    }
}
