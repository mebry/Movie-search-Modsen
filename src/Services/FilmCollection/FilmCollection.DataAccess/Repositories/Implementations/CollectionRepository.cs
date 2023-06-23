using FilmCollection.DataAccess.Contexts;
using FilmCollection.DataAccess.Models;
using FilmCollection.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FilmCollection.DataAccess.Repositories.Implementations
{
    internal class CollectionRepository : RepositoryBase<CollectionModel>, ICollectionRepository
    {
        private readonly FilmCollectionContext _filmCollectionContext;

        public CollectionRepository(FilmCollectionContext filmCollectionContext)
            : base(filmCollectionContext)
        {
            _filmCollectionContext = filmCollectionContext;
        }

        public async Task CreateCollectionAsync(CollectionModel collection)
        {
            Create(collection);
            await _filmCollectionContext.SaveChangesAsync();
        }

        public async Task DeleteCollectionAsync(CollectionModel collection)
        {
            Delete(collection);
            await _filmCollectionContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<CollectionModel>> GetAllCollectionsAsync(bool trackChanges)
        {
            return await GetAllAsync(trackChanges).ToListAsync();
        }

        public async Task<CollectionModel> GetCollectionAsync(Guid id, bool trackChanges)
        {
            return await GetByConditionAsync(c => c.Id.Equals(id),trackChanges).SingleOrDefaultAsync();
        }

        public async Task<CollectionModel> GetCollectionByTitleAndDescriptionAsync(string title, string description, bool trackChanges)
        {
            return await GetByConditionAsync(c => c.Title == title && c.Description == description, trackChanges).SingleOrDefaultAsync();
        }

        public async Task<CollectionModel> GetCollectionByTitleAsync(string title, bool trackChanges)
        {
            return await GetByConditionAsync(c => c.Title == title, trackChanges).FirstOrDefaultAsync();
        }

        public async Task UpdateCollectionAsync(CollectionModel collection)
        {
            Update(collection);
            await _filmCollectionContext.SaveChangesAsync();
        }
    }
}
