using FilmCollection.BusinessLogic.DTOs.RequestDTOs;
using FilmCollection.BusinessLogic.DTOs.ResponseDTOs;
using FilmCollection.Shared.RequestFeatures;
using FilmCollection.Shared.RequestParameters;

namespace FilmCollection.BusinessLogic.Services.Interfaces
{
    public interface IBaseFilmInfoService
    {
        Task<BaseFilmInfoResponseDto> CreateBaseFilmInfoAsync(BaseFilmInfoRequestDto request);
        Task UpdateBaseFilmInfoAsync(Guid id, BaseFilmInfoRequestDto request);
        Task DeleteBaseFilInfoAsync(Guid id);  
        Task<BaseFilmInfoResponseDto> GetBaseFilmInfoAsync(Guid id);
        Task<(IEnumerable<BaseFilmInfoResponseDto> baseFilmInfos, MetaData metaData)> GetBaseFilmInfosAsync(FilmParameters filmParameters);
    }
}
