using FilmCollection.BusinessLogic.DTOs.RequestDTOs;
using FilmCollection.BusinessLogic.DTOs.ResponseDTOs;
using FilmCollection.BusinessLogic.Services.Interfaces;
using FilmCollection.BusinessLogic.Validators.ServiceValidators.Interfaces;
using FilmCollection.DataAccess.Repositories.Interfaces;
using MapsterMapper;

namespace FilmCollection.BusinessLogic.Services.Implementations
{
    internal class FilmCollectionService : IFilmCollectionService
    {
        private readonly IMapper _mapper;
        private readonly IFilmCollectionRepository _filmCollectionRepository;
        private readonly IFilmCollectionServiceValidator _filmCollectonServiceValidator;
        private readonly IBaseFilmInfoServiceValidator _baseFilmInfoServiceValidator;
        private readonly ICollectionServiceValidator _collectionServiceValidator;

        public FilmCollectionService(IMapper mapper, 
            IFilmCollectionRepository filmCollectionRepository,
            IFilmCollectionServiceValidator filmCollectonServiceValidator,
            IBaseFilmInfoServiceValidator baseFilmInfoServiceValidator,
            ICollectionServiceValidator collectionServiceValidator)
        {
            _mapper = mapper;
            _filmCollectionRepository = filmCollectionRepository;
            _filmCollectonServiceValidator = filmCollectonServiceValidator;
            _baseFilmInfoServiceValidator = baseFilmInfoServiceValidator;
            _collectionServiceValidator = collectionServiceValidator;  
        }

        public async Task<FilmCollectionResponseDto> CreateFilmCollectionAssociationAsync(FilmCollectionRequestDto filmCollectionRequestDto)
        {
            await _filmCollectonServiceValidator.CheckIfAssociationBetweenFilmInfoAndCollectionNotExistsAsync(filmCollectionRequestDto.BaseFilmInfoId, filmCollectionRequestDto.CollectionModelId);
            await _collectionServiceValidator.CheckIfCollectionExistsAsync(filmCollectionRequestDto.CollectionModelId);
            await _baseFilmInfoServiceValidator.CheckIfBaseFilmInfoExistsAsync(filmCollectionRequestDto.BaseFilmInfoId);
            var associationToCreate = _mapper.Map<FilmCollection.DataAccess.Models.FilmCollection>(filmCollectionRequestDto);
            await _filmCollectionRepository.CreateFilmCollectionAsync(associationToCreate);
            return _mapper.Map<FilmCollectionResponseDto>(associationToCreate);
        }

        public async Task<FilmCollectionResponseDto> GetFilmCollectionAsscoationAsync(Guid filmId, Guid collectionId)
        {
            var associationToReturn = await _filmCollectonServiceValidator.CheckIfAsocciationBetweenFilmInfoAndCollectionExistsAndGetAsync(filmId, collectionId, false);
            return _mapper.Map<FilmCollectionResponseDto>(associationToReturn);
        }

        public async Task DeleteFilmCollectionAssociationAsync(Guid collectionId, Guid filmId)
        {
            var association = await _filmCollectonServiceValidator.CheckIfAsocciationBetweenFilmInfoAndCollectionExistsAndGetAsync(filmId, collectionId, true);
            await _filmCollectionRepository.DeleteFilmCollectionAsync(association);
        }

    }
}
