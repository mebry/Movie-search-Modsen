using FilmCollection.DataAccess.Contexts;
using FilmCollection.DataAccess.Models;
using FilmCollection.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmCollection.DataAccess.Repositories.Implementations
{
    internal class CollectionRepository : RepositoryBase<Collection>, ICollectionRepository
    {
        private readonly FilmCollectionContext _filmCollectionContext;

        public CollectionRepository(FilmCollectionContext filmCollectionContext)
            : base(filmCollectionContext)
        {
            _filmCollectionContext = filmCollectionContext;
        }

        public async Task CreateCollectionAsync(Collection collection)
        {
            Create(collection);
            await _filmCollectionContext.SaveChangesAsync();
        }

        public async Task DeleteCollectionAsync(Collection collection)
        {
            Delete(collection);
            await _filmCollectionContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Collection>> GetAllCollectionsAsync(bool trackChanges)
        {
            return await GetAllAsync(trackChanges).ToListAsync();
        }

        public async Task<Collection> GetCollectionAsync(Guid id, bool trackChanges)
        {
            return await GetByConditionAsync(c => c.Id.Equals(id),trackChanges).SingleOrDefaultAsync();
        }

        public async Task<Collection> GetCollectionByTitleAndDescriptionAsync(string title, string description, bool trackChanges)
        {
            return await GetByConditionAsync(c => c.Title == title && c.Description == description, trackChanges).SingleOrDefaultAsync();
        }

        public async Task<Collection> GetCollectionByTitleAsync(string title, bool trackChanges)
        {
            return await GetByConditionAsync(c => c.Title == title, trackChanges).FirstOrDefaultAsync();
        }

        public async Task UpdateCollectionAsync(Collection collection)
        {
            Update(collection);
            await _filmCollectionContext.SaveChangesAsync();
        }
    }
}
