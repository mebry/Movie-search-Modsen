using FilmCollection.BusinessLogic.DTOs.RequestDTOs;
using FilmCollection.BusinessLogic.DTOs.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmCollection.BusinessLogic.Services.Interfaces
{
    public interface IBaseFilmInfoService
    {
        Task<BaseFilmInfoResponseDto> CreateBaseFilmInfoAsync(BaseFilmInfoRequestDto request);
        Task UpdateBaseFilmInfoAsync(Guid id, BaseFilmInfoRequestDto request);
        Task DeleteBaseFilInfoAsync(Guid id);  
        Task<IEnumerable<BaseFilmInfoResponseDto>> GetAllBaseFilmInfosAsync();
        Task<BaseFilmInfoResponseDto> GetBaseFilmInfoAsync(Guid id);

    }
}
