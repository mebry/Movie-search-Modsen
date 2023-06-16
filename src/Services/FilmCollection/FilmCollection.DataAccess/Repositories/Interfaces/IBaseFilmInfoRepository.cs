using FilmCollection.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FilmCollection.DataAccess.Repositories.Interfaces
{
    public interface IBaseFilmInfoRepository
    {
        Task AddBaseFilmInfoAsync(BaseFilmInfo baseFilmInfo);
        Task DeleteBaseFilmInfoAsync(BaseFilmInfo baseFilmInfo);
        Task UpdateBaseFilmInfoAsync(BaseFilmInfo baseFilmInfo);
        Task<BaseFilmInfo> GetBaseFilmInfoByIdAsync(Guid id, bool trackCahnges);
        Task<IEnumerable<BaseFilmInfo>> GetBaseFilmInfosAsync(bool trackCahnges);
        Task<BaseFilmInfo> GetBaseFilmInfoByTitleAndReleaseDate(string title, DateOnly releaseDate, bool trackChanges);
    }
}
