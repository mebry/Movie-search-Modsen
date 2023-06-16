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
    internal class BaseFilmInfoRepository : RepositoryBase<BaseFilmInfo>, IBaseFilmInfoRepository
    {
        private readonly FilmCollectionContext _filmCollectionContext;

        public BaseFilmInfoRepository(FilmCollectionContext filmCollectionContext)
            : base(filmCollectionContext)
        {
            _filmCollectionContext = filmCollectionContext;
        }

        public async Task AddBaseFilmInfoAsync(BaseFilmInfo baseFilmInfo)
        {
            Create(baseFilmInfo);
            await _filmCollectionContext.SaveChangesAsync();
        }

        public async Task DeleteBaseFilmInfoAsync(BaseFilmInfo baseFilmInfo)
        {
            Delete(baseFilmInfo);
            await _filmCollectionContext.SaveChangesAsync();
        }

        public async Task<BaseFilmInfo> GetBaseFilmInfoByIdAsync(Guid id, bool trackCahnges)
        {
            return await GetByConditionAsync(b => b.Id.Equals(id), trackCahnges).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<BaseFilmInfo>> GetBaseFilmInfosAsync(bool trackCahnges)
        {
            return await GetAllAsync(trackCahnges).ToListAsync();
        }

        public async Task UpdateBaseFilmInfoAsync(BaseFilmInfo baseFilmInfo)
        {
            Update(baseFilmInfo);
            await _filmCollectionContext.SaveChangesAsync();
        }
    }
}
