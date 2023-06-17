using FilmCollection.BusinessLogic.DTOs.RequestDTOs;
using FilmCollection.BusinessLogic.DTOs.ResponseDTOs;
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
    internal class FilmGenreService : IFilmGenreService
    {
        private readonly IMapper _mapper;
        private readonly IFilmGenreRepository _filmGenreRepository;
        private readonly IFilmGenreServiceValidator _filmGenreServiceValidator;
        private readonly IGenreServiceValidator _genreServiceValidator;
        private readonly IBaseFilmInfoServiceValidator _baseFilmInfoServiceValidator;

        public FilmGenreService(IMapper mapper,
            IFilmGenreRepository filmGenreRepository,
            IFilmGenreServiceValidator filmGenreServiceValidator,
            IGenreServiceValidator genreServiceValidator,
            IBaseFilmInfoServiceValidator baseFilmInfoServiceValidator
            )
        {
            _mapper = mapper;
            _filmGenreRepository = filmGenreRepository;
            _filmGenreServiceValidator = filmGenreServiceValidator;
            _genreServiceValidator = genreServiceValidator;
            _baseFilmInfoServiceValidator = baseFilmInfoServiceValidator;
        }   

        public async Task CreateFilmGenreAsync(FilmGenreRequestDto filmGenreRequest)
        {
            await _filmGenreServiceValidator.CheckIfAssociationBetweenBaseFilmInfoAndGenreDoesntExistsAndGetAsync(filmGenreRequest.GenreId, filmGenreRequest.BaseFilmInfoId);
            await _baseFilmInfoServiceValidator.CheckIfBaseFilmInfoExistsAsync(filmGenreRequest.BaseFilmInfoId);
            await _genreServiceValidator.CheckIfGenreExistsAsync(filmGenreRequest.GenreId);
            await _filmGenreRepository.CreateFilmGenreAsync(_mapper.Map<FilmGenre>(filmGenreRequest));
        }

        public async Task DeleteFilmGenreAsync(FilmGenreRequestDto filmGenreRequestDto)
        {
            var filmGenreToDelete = await _filmGenreServiceValidator.CheckIfAssociationBetweenBaseFilmInfoAndGenreExistsAndGetAsync(filmGenreRequestDto.GenreId, filmGenreRequestDto.BaseFilmInfoId, true);
            await _filmGenreRepository.DeleteFilmGenreAsync(filmGenreToDelete);
        }


    }
}
