using FilmCollection.DataAccess.Models;

namespace FilmCollection.DataAccess.Repositories.Interfaces
{
    public interface ICollectionRepository
    {
        Task CreateCollectionAsync(Collection collection);
        Task DeleteCollectionAsync(Collection collection);
        Task UpdateCollectionAsync(Collection collection);
        Task<IEnumerable<Collection>> GetAllCollectionsAsync(bool trackChanges);
        Task<Collection> GetCollectionAsync(Guid id, bool trackChanges);
        Task<Collection> GetCollectionByTitleAndDescriptionAsync(string title, string description, bool trackChanges);
        Task<Collection> GetCollectionByTitleAsync(string title, bool trackChanges);
    }
}
