using Film.BusinessLogic.DTOs.RequestDTOs;
using Film.BusinessLogic.DTOs.ResponseDTOs;
using Film.BusinessLogic.Exceptions.AlreadyExists;
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
    /// Service responsible for managing genres.
    /// </summary>
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        private readonly ILogger<GenreService> _logger;
        private readonly IValidator<GenreRequestDTO> _validator;

        public GenreService(IGenreRepository genreRepository, ILogger<GenreService> logger, IValidator<GenreRequestDTO> validator)
        {
            _genreRepository = genreRepository;
            _logger = logger;
            _validator = validator;
        }

        /// <summary>
        /// Creates a new genre asynchronously.
        /// </summary>
        /// <param name="genre">The genre to create.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// <exception cref="BadRequestException">Exception if the model isn't valid.</exception>
        /// <exception cref="GenreAlreadyExistsException">Exception if the object is found.</exception>
        public async Task<GenreResponseDTO> CreateAsync(GenreRequestDTO genre)
        {
            var validationResult = await _validator.ValidateAsync(genre);

            if (!validationResult.IsValid)
            {
                _logger.LogError("The model is invalid");
                throw new BadRequestException(validationResult.GetErrorMessages());
            }

            var foundGenre = _genreRepository.GetGenreByNameAsync(genre.Name);

            if (foundGenre is not null)
            {
                _logger.LogError("The model could not be created because such a model already exists");
                throw new GenreAlreadyExistsException();
            }

            var mappedModel = genre.Adapt<Genre>();
            mappedModel.Id = Guid.NewGuid();

            _genreRepository.Create(mappedModel);
            await _genreRepository.SaveChangesAsync();

            return mappedModel.Adapt<GenreResponseDTO>();
        }

        /// <summary>
        /// Deletes a genre asynchronously.
        /// </summary>
        /// <param name="id">The Id of the genre to delete.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// <exception cref="GenreNotFoundException">Exception if the object is not found.</exception>
        public async Task DeleteAsync(Guid id)
        {
            var foundGenre = await _genreRepository.GetByIdAsync(id);

            if (foundGenre is null)
            {
                _logger.LogError("The genre was not found");
                throw new GenreNotFoundException(id);
            }

            _genreRepository.Delete(id);

            await _genreRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Gets all genres asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task<IEnumerable<GenreResponseDTO>> GetAllAsync()
        {
            var foundGenres = await _genreRepository.GetGenresAsync();

            return foundGenres.Adapt<List<GenreResponseDTO>>();
        }

        /// <summary>
        /// Gets a genre by Id asynchronously.
        /// </summary>
        /// <param name="id">The Id of the genre.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// <exception cref="GenreNotFoundException">Exception if the object is not found.</exception>
        public async Task<GenreResponseDTO> GetByIdAsync(Guid id)
        {
            var foundGenre = await _genreRepository.GetByIdAsync(id);

            if (foundGenre is null)
            {
                _logger.LogError("The genre was not found");
                throw new GenreNotFoundException(id);
            }

            return foundGenre.Adapt<GenreResponseDTO>();
        }

        /// <summary>
        /// Gets a genre by name asynchronously.
        /// </summary>
        /// <param name="name">The name of the genre.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// <exception cref="NotFoundException">Exception if the object is not found by name.</exception>
        public async Task<GenreResponseDTO> GetByNameAsync(string name)
        {
            var foundGenre = await _genreRepository.GetGenreByNameAsync(name);

            if (foundGenre is null)
            {
                _logger.LogError("The genre was not found by name");
                throw new NotFoundException("The genre with this name wasn't found");
            }

            return foundGenre.Adapt<GenreResponseDTO>();
        }

        /// <summary>
        /// Updates a genre asynchronously.
        /// </summary>
        /// <param name="id">The Id of the genre to update.</param>
        /// <param name="genre">The updated genre data.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// <exception cref="BadRequestException">Exception if the model isn't valid.</exception>
        /// <exception cref="GenreNotFoundException">Exception if the object is not found.</exception>
        public async Task UpdateAsync(Guid id, GenreRequestDTO genre)
        {
            var validationResult = await _validator.ValidateAsync(genre);

            if (!validationResult.IsValid)
            {
                _logger.LogError("The model is invalid");
                throw new BadRequestException(validationResult.GetErrorMessages());
            }

            var foundGenre = await _genreRepository.GetByIdAsync(id);

            if (foundGenre is null)
            {
                _logger.LogError("The genre was not found");
                throw new GenreNotFoundException(id);
            }

            var mappedModel = genre.Adapt<Genre>();

            mappedModel.Id = Guid.NewGuid();

            _genreRepository.Update(mappedModel);

            await _genreRepository.SaveChangesAsync();
        }
    }
}
