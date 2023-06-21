using FilmCollection.DataAccess.Contexts;
using FilmCollection.DataAccess.Models;
using FilmCollection.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FilmCollection.DataAccess.Repositories.Implementations
{
    internal class GenreRepository : RepositoryBase<Genre>, IGenreRepository
    {
        private FilmCollectionContext _filmCollectionContext;

        public GenreRepository(FilmCollectionContext filmCollectionContext)
            :base(filmCollectionContext)
        {
            _filmCollectionContext = filmCollectionContext;
        }   

        public async Task CreateGenreAsync(Genre genre)
        {
            Create(genre);
            await _filmCollectionContext.SaveChangesAsync();
        }

        public async Task DeleteGenreAsync(Genre genre)
        {
            Delete(genre);
            await _filmCollectionContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Genre>> GetAllGenresAsync(bool trackChanges)
        {
            return await GetAllAsync(trackChanges).ToListAsync();
        }

        public async Task<Genre> GetGenreByNameAsync(string name, bool trackChanges)
        {
            return await GetByConditionAsync(g => name.ToLower() == g.Name.ToLower(), trackChanges).SingleOrDefaultAsync();
        }

        public async Task<Genre> GetGenreByIdAsync(Guid id, bool trackChanges)
        {
            return await GetByConditionAsync(g => g.Id.Equals(id), trackChanges).SingleOrDefaultAsync();
        }
    }
}
