using FilmCollection.BusinessLogic.DTOs.RequestDTOs;
using FilmCollection.BusinessLogic.DTOs.ResponseDTOs;
using FilmCollection.BusinessLogic.Services.Interfaces;
using FilmCollection.BusinessLogic.Validators.ServiceValidators.Interfaces;
using FilmCollection.DataAccess.Models;
using FilmCollection.DataAccess.Repositories.Interfaces;
using MapsterMapper;

namespace FilmCollection.BusinessLogic.Services.Implementations
{
    internal class GenreService : IGenreService
    {
        private readonly IMapper _mapper;
        private readonly IGenreRepository _genreRepository;
        private readonly IGenreServiceValidator _genreServiceValidator;

        public GenreService(IMapper mapper, IGenreRepository genreRepository, IGenreServiceValidator genreServiceValidator)
        {
            _mapper = mapper;
            _genreRepository = genreRepository;
            _genreServiceValidator = genreServiceValidator;
        }   

        public async Task<GenreResponseDto> CreateGenreAsync(GenreRequestDto genreRequestDto)
        {
            await _genreServiceValidator.CheckIfGenreWithGivenNameDoesntExistsAsync(genreRequestDto.Name);
            var mappedGenre = _mapper.Map<Genre>(genreRequestDto);
            mappedGenre.Id = new Guid();
            await _genreRepository.CreateGenreAsync(mappedGenre);
            return _mapper.Map<GenreResponseDto>(mappedGenre);
        }

        public async Task DeleteGenreAsync(Guid genreId)
        {
            var genre = await _genreServiceValidator.CheckIfGenreExistsAndGetAsync(genreId, true);
            await _genreRepository.DeleteGenreAsync(genre);
        }

        public async Task<GenreResponseDto> GetGenreAsync(Guid genreId)
        {
            var genre = await _genreServiceValidator.CheckIfGenreExistsAndGetAsync(genreId, false);
            return _mapper.Map<GenreResponseDto>(genre);
        }

        public async Task<IEnumerable<GenreResponseDto>> GetAllGenresAsync()
        {
            var genres = await _genreRepository.GetAllGenresAsync(false);
            return _mapper.Map<IEnumerable<GenreResponseDto>>(genres);
        }
    }
}
