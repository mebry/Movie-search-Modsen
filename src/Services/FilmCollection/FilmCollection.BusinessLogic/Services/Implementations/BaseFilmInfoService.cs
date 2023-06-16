using FilmCollection.BusinessLogic.DTOs.RequestDTOs;
using FilmCollection.BusinessLogic.DTOs.ResponseDTOs;
using FilmCollection.BusinessLogic.Services.Interfaces;
using FilmCollection.BusinessLogic.ServiceValidators.Interfaces;
using FilmCollection.DataAccess.Models;
using FilmCollection.DataAccess.Repositories.Interfaces;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmCollection.BusinessLogic.Services.Implementations
{
    internal class BaseFilmInfoService : IBaseFilmInfoService
    {
        private readonly IBaseFilmInfoRepository _baseFilmInfoRepository;
        private readonly IBaseFilmInfoServiceValidator _baseFilmInfoServiceValidator;
        private readonly IMapper _mapper;

        public BaseFilmInfoService(IBaseFilmInfoRepository baseFilmInfoRepository,
            IBaseFilmInfoServiceValidator baseFilmInfoServiceValidator,
            IMapper mapper)
        {
            _baseFilmInfoRepository = baseFilmInfoRepository;
            _baseFilmInfoServiceValidator = baseFilmInfoServiceValidator;
            _mapper = mapper;
        }

        public async Task<BaseFilmInfoResponseDto> CreateBaseFilmInfoAsync(BaseFilmInfoRequestDto request)
        {
            await _baseFilmInfoServiceValidator.CheckIfBaseFilmInfoNotExistsWithGivingTitleAndReleaseDateAsync(request.ReleaseDate, request.Title);
            var mappedBaseFilmInfo = _mapper.Map<BaseFilmInfo>(request);
            mappedBaseFilmInfo.Id = new Guid();
            await _baseFilmInfoRepository.AddBaseFilmInfoAsync(mappedBaseFilmInfo);
            return _mapper.Map<BaseFilmInfoResponseDto>(mappedBaseFilmInfo);
        }

        public async Task DeleteBaseFilInfoAsync(Guid id)
        {
            var validatedBaseFilmInfo = await _baseFilmInfoServiceValidator.CheckIfBaseFilmInfoExistsAndGetAsync(id, true);
            await _baseFilmInfoRepository.DeleteBaseFilmInfoAsync(validatedBaseFilmInfo);
        }

        public async Task<IEnumerable<BaseFilmInfoResponseDto>> GetAllBaseFilmInfosAsync()
        {
            return _mapper.Map<IEnumerable<BaseFilmInfoResponseDto>>(await _baseFilmInfoRepository.GetBaseFilmInfosAsync(false));
        }

        public async Task<BaseFilmInfoResponseDto> GetBaseFilmInfoAsync(Guid id)
        {
            var validatedBaseFilmInfo = await _baseFilmInfoServiceValidator.CheckIfBaseFilmInfoExistsAndGetAsync(id, false);
            return _mapper.Map<BaseFilmInfoResponseDto>(validatedBaseFilmInfo);
        }

        public async Task UpdateBaseFilmInfoAsync(Guid id, BaseFilmInfoRequestDto request)
        {
            await _baseFilmInfoServiceValidator.CheckIfBaseFilmInfoExists(id);
            var mappedBaseFilmInfo = _mapper.Map<BaseFilmInfo>(request);
            mappedBaseFilmInfo.Id = id;
            await _baseFilmInfoRepository.UpdateBaseFilmInfoAsync(mappedBaseFilmInfo);
        }
    }
}
