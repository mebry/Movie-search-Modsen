using Film.BusinessLogic.DTOs.RequestDTOs;
using Shared.Exceptions;
using Film.BusinessLogic.Exceptions.NotFound;
using Film.BusinessLogic.Extensions;
using Film.BusinessLogic.Services.Interfaces;
using Film.DataAccess.Entities;
using Film.DataAccess.Repositories.Interfaces;
using FluentValidation;
using Mapster;
using Microsoft.Extensions.Logging;

namespace Film.BusinessLogic.Services.Implementations
{
    /// <summary>
    /// Service responsible for managing film genres.
    /// </summary>
    public class FilmGenreService : IFilmGenreService
    {
        private readonly IFilmGenreRepository _filmGenreRepository;
        private readonly IFilmRepository _filmRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly ILogger<FilmGenreService> _logger;
        private readonly IValidator<FilmGenreRequestDTO> _validator;

        public FilmGenreService(IFilmGenreRepository filmGenreRepository, IFilmRepository filmRepository,
            IGenreRepository genreRepository, ILogger<FilmGenreService> logger, IValidator<FilmGenreRequestDTO> validator)
        {
            _filmGenreRepository = filmGenreRepository;
            _filmRepository = filmRepository;
            _genreRepository = genreRepository;
            _logger = logger;
            _validator = validator;
        }

        /// <summary>
        /// Creates a new film genre association asynchronously.
        /// </summary>
        /// <param name="filmGenre">The film genre association to create.</param>
        /// <exception cref="BadRequestException">Exception if the model isn't valid.</exception>
        public async Task CreateAsync(FilmGenreRequestDTO filmGenre)
        {
            var validationResult = await _validator.ValidateAsync(filmGenre);

            if (!validationResult.IsValid)
            {
                _logger.LogError("The model is invalid");
                throw new BadRequestException(validationResult.GetErrorMessages());
            }

            await CheckIfFilmAndGenreExists(filmGenre.FilmId, filmGenre.GenreId);

            var mappedModel = filmGenre.Adapt<FilmGenre>();

            _filmGenreRepository.Create(mappedModel);
            await _filmGenreRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes a film genre association asynchronously.
        /// </summary>
        /// <param name="filmId">The Id of the film.</param>
        /// <param name="genreId">The Id of the genre.</param>
        public async Task DeleteAsync(Guid filmId, Guid genreId)
        {
            await CheckIfFilmAndGenreExists(filmId, genreId);

            _filmGenreRepository.Delete(filmId, genreId);
            await _filmGenreRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Checks if the film and genre exist.
        /// </summary>
        /// <param name="filmId">The Id of the film.</param>
        /// <param name="genreId">The Id of the genre.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// <exception cref="FilmNotFoundException">Exception if the object is not found.</exception>
        /// <exception cref="GenreNotFoundException">Exception if the object is not found.</exception>
        private async Task CheckIfFilmAndGenreExists(Guid filmId, Guid genreId)
        {
            var foundFilm = await _filmRepository.GetByIdAsync(filmId);

            if (foundFilm is null)
            {
                _logger.LogError("The film was not found");
                throw new FilmNotFoundException(filmId);
            }

            var foundGenre = await _genreRepository.GetByIdAsync(genreId);

            if (foundGenre is null)
            {
                _logger.LogError("The genre was not found");
                throw new GenreNotFoundException(genreId);
            }
        }
    }
}
