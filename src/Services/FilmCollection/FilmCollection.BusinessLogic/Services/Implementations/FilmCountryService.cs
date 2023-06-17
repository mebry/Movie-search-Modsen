using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmCollection.BusinessLogic.Services.Interfaces;
using FilmCollection.DataAccess.Repositories.Interfaces;
using MapsterMapper;
using FilmCollection.BusinessLogic.ServiceValidators.Interfaces;
using FilmCollection.BusinessLogic.DTOs.ResponseDTOs;
using FilmCollection.BusinessLogic.DTOs.RequestDTOs;
using FilmCollection.DataAccess.Models;

namespace FilmCollection.BusinessLogic.Services.Implementations
{
    internal class FilmCountryService : IFilmCountryService
    {
        private readonly IMapper _mapper;
        private readonly IFilmCountryRepository _filmCountryRepository;
        private readonly IBaseFilmInfoServiceValidator _baseFilmInfoServiceValidator;
        private readonly IFilmCountryServiceValidator _filmCountryServiceValidator;

        public FilmCountryService(IMapper mapper,
            IFilmCountryServiceValidator filmCountryServiceValidator,
            IFilmCountryRepository filmCountryRepository,
            IBaseFilmInfoServiceValidator baseFilmInfoServiceValidator)
        {
            _mapper = mapper;
            _filmCountryRepository = filmCountryRepository;
            _baseFilmInfoServiceValidator = baseFilmInfoServiceValidator;
            _filmCountryServiceValidator = filmCountryServiceValidator;
        }

        public async Task<FilmCountryResponseDto> CreateFilmCountry(FilmCountryRequestDto filmCountryRequest)
        {
            await _filmCountryServiceValidator.CheckIfAssociationBetweenBaseFilmInfoAndCountryDoesntExistsAndGetAsync(filmCountryRequest.CountryId, filmCountryRequest.BaseFilmInfoId);
            await _baseFilmInfoServiceValidator.CheckIfBaseFilmInfoExistsAsync(filmCountryRequest.BaseFilmInfoId);
            var mappedFilmCountry = _mapper.Map<FilmCountry>(filmCountryRequest);
            await _filmCountryRepository.CreateFilmCountryAsync(mappedFilmCountry);
            return _mapper.Map<FilmCountryResponseDto>(mappedFilmCountry);
        }

        public async Task DeleteFilmCountry(FilmCountryRequestDto filmCountryRequest)
        {
            var association = _filmCountryServiceValidator.CheckIfAssociationBetweenBaseFilmInfoAndCountryExistsAndGetAsync(filmCountryRequest.CountryId, filmCountryRequest.BaseFilmInfoId, true);
            await _filmCountryRepository.DeleteFilmCountryAsync(_mapper.Map<FilmCountry>(filmCountryRequest));
        }
        

    }
}
