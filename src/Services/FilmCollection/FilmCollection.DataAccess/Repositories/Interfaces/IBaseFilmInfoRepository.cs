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
        Task AddBaseFilmInfo(BaseFilmInfo baseFilmInfo);
        Task DeleteBaseFilmInfo(BaseFilmInfo baseFilmInfo);
        Task UpdateBaseFilmInfo(BaseFilmInfo baseFilmInfo);
        Task<BaseFilmInfo> GetBaseFilmInfoByIdAsync(Guid id, bool trackCahnges);
        Task<IEnumerable<BaseFilmInfo>> GetBaseFilmInfosAsync(bool trackCahnges);
        Task<IEnumerable<BaseFilmInfo>> GetBaseFilmInfosByConditionAsync(Expression<Func<BaseFilmInfo, bool>> expression, bool trackChanges);
    }
}
