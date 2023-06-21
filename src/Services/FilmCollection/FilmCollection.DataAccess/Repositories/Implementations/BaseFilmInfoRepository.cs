using FilmCollection.DataAccess.Contexts;
using FilmCollection.DataAccess.Models;
using FilmCollection.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using FilmCollection.Shared.RequestParameters;
using FilmCollection.DataAccess.Extensions;
using FilmCollection.Shared.RequestFeatures;

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
            return await GetByConditionAsync(b => b.Id.Equals(id), trackCahnges).IncludeAllRelatedData().SingleOrDefaultAsync();
        }

        public async Task<PagedList<BaseFilmInfo>> GetFilteredBaseFilmInfosAsync(FilmParameters filmParameters, bool trackChanges)
        {
            var filteredList = await GetAllAsync(trackChanges)
                         .IncludeAllRelatedData()
                         .Search(filmParameters.SearchTerm)
                         .FilterFilmInfosByReleaseYear(filmParameters.MinReleaseYear, filmParameters.MaxReleaseYear)
                         .GenresContains(filmParameters.GenreId)
                         .CountriesContains(filmParameters.CountryId)
                         .CollectionContains(filmParameters.CollectionId)
                         .Sort(filmParameters.OrderBy)
                         .ToListAsync();

            return PagedList<BaseFilmInfo>.ToPagedList(filteredList, filmParameters.PageNumber, filmParameters.PageSize);
        }

        public async Task<BaseFilmInfo> GetByIdWithAllRelatedDataAsync(Guid id, bool trackChanges)
        {
            return await GetByConditionAsync(b => b.Id.Equals(id), trackChanges).IncludeAllRelatedData().SingleOrDefaultAsync();
        }

        public async Task<BaseFilmInfo> GetBaseFilmInfoByTitleAndReleaseDateAsync(string title, DateOnly releaseDate, bool trackChanges)
        {
            return await GetByConditionAsync(b => b.ReleaseDate == releaseDate && b.Title == title, trackChanges).FirstOrDefaultAsync();
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
