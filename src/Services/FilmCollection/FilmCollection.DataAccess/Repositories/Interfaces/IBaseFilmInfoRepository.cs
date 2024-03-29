﻿using FilmCollection.DataAccess.Models;
using FilmCollection.Shared.RequestFeatures;
using FilmCollection.Shared.RequestParameters;

namespace FilmCollection.DataAccess.Repositories.Interfaces
{
    public interface IBaseFilmInfoRepository
    {
        Task AddBaseFilmInfoAsync(BaseFilmInfo baseFilmInfo);
        Task DeleteBaseFilmInfoAsync(BaseFilmInfo baseFilmInfo);
        Task UpdateBaseFilmInfoAsync(BaseFilmInfo baseFilmInfo);
        Task<BaseFilmInfo> GetBaseFilmInfoByIdAsync(Guid id, bool trackCahnges);
        Task<IEnumerable<BaseFilmInfo>> GetBaseFilmInfosAsync(bool trackCahnges);
        Task<BaseFilmInfo> GetBaseFilmInfoByTitleAndReleaseDateAsync(string title, DateOnly releaseDate, bool trackChanges);
        Task<PagedList<BaseFilmInfo>> GetFilteredBaseFilmInfosAsync(FilmParameters filmParameters, bool trackChanges);
    }
}
