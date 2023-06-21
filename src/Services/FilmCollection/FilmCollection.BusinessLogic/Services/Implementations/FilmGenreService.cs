using FilmCollection.BusinessLogic.DTOs.RequestDTOs;
using FilmCollection.BusinessLogic.DTOs.ResponseDTOs;
using FilmCollection.BusinessLogic.Services.Interfaces;
using FilmCollection.BusinessLogic.Validators.ServiceValidators.Interfaces;
using FilmCollection.DataAccess.Models;
using FilmCollection.DataAccess.Repositories.Interfaces;
using MapsterMapper;

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

        public async Task<FilmGenreResponseDto> CreateFilmGenreAsync(FilmGenreRequestDto filmGenreRequest)
        {
            await _filmGenreServiceValidator.CheckIfAssociationBetweenBaseFilmInfoAndGenreDoesntExistsAsync(filmGenreRequest.GenreId, filmGenreRequest.BaseFilmInfoId);
            await _baseFilmInfoServiceValidator.CheckIfBaseFilmInfoExistsAsync(filmGenreRequest.BaseFilmInfoId);
            await _genreServiceValidator.CheckIfGenreExistsAsync(filmGenreRequest.GenreId);
            var filmGenreToCreate = _mapper.Map<FilmGenre>(filmGenreRequest);
            await _filmGenreRepository.CreateFilmGenreAsync(filmGenreToCreate);
            return _mapper.Map<FilmGenreResponseDto>(filmGenreToCreate);
        }

        public async Task<FilmGenreResponseDto> GetFilmGenreAsync(Guid filmId, Guid genreId)
        {
            var association = await _filmGenreServiceValidator.CheckIfAssociationBetweenBaseFilmInfoAndGenreExistsAndGetAsync(genreId, filmId, false);
            return _mapper.Map<FilmGenreResponseDto>(association);
        }

        public async Task DeleteFilmGenreAsync(Guid filmId, Guid genreId)
        {
            var filmGenreToDelete = await _filmGenreServiceValidator.CheckIfAssociationBetweenBaseFilmInfoAndGenreExistsAndGetAsync(genreId, filmId, true);
            await _filmGenreRepository.DeleteFilmGenreAsync(filmGenreToDelete);
        }


    }
}
