using FilmCollection.BusinessLogic.DTOs.RequestDTOs;
using FilmCollection.BusinessLogic.Services.Interfaces;
using FilmCollection.BusinessLogic.Validators.ServiceValidators.Interfaces;
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

        public async Task CreateFilmCollectionAssociationAsync(FilmCollectionRequestDto filmCollectionRequestDto)
        {
            await _filmCollectonServiceValidator.CheckIfAssociationBetweenFilmInfoAndCollectionNotExistsAsync(filmCollectionRequestDto.BaseFilmInfoId, filmCollectionRequestDto.CollectionId);
            await _collectionServiceValidator.CheckIfCollectionExistsAsync(filmCollectionRequestDto.CollectionId);
            await _baseFilmInfoServiceValidator.CheckIfBaseFilmInfoExistsAsync(filmCollectionRequestDto.BaseFilmInfoId);
            await _filmCollectionRepository.CreateFilmCollectionAsync(_mapper.Map<FilmCollection.DataAccess.Models.FilmCollection>(filmCollectionRequestDto));
        }

        public async Task DeleteFilmCollectionAssociationAsync(FilmCollectionRequestDto filmCollectionRequestDto)
        {
            var association = await _filmCollectonServiceValidator.CheckIfAsocciationBetweenFilmInfoAndCollectionExistsAndGetAsync(filmCollectionRequestDto.BaseFilmInfoId, filmCollectionRequestDto.CollectionId, true);
            await _filmCollectionRepository.DeleteFilmCollectionAsync(association);
        }

    }
}
