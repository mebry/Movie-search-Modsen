using FluentValidation;
using FluentValidation.Results;
using Mapster;
using Microsoft.Extensions.Logging;
using Rating.BusinessLogic.DTOs;
using Rating.BusinessLogic.Extensions;
using Rating.DataAccess.Entities;
using Rating.DataAccess.Repositories.FilmRepositories;
using Shared.Exceptions;

namespace Rating.BusinessLogic.Services.FilmServices
{
    internal class FilmService : IFilmService
    {
        private readonly IFilmRepository _filmRepository;
        private readonly ILogger<FilmService> _logger;
        private readonly IValidator<FilmDTO> _validator;

        public FilmService(IFilmRepository filmRepository, ILogger<FilmService> logger, IValidator<FilmDTO> validator)
        {
            _filmRepository = filmRepository;
            _logger = logger;
            _validator = validator;
        }

        public async Task<FilmDTO> CreateAsync(Guid id)
        {
            var existingFilm = await _filmRepository.GetByIdAsync(id);

            if(existingFilm is not null)
            {
                _logger.LogError("The creation attempt failed. This id is already in use");

                throw new AlreadyExistsException("This id is already used");
            }

            var filmDto = new FilmDTO()
            {
                Id = id
            };

            ValidationResult result = await _validator.ValidateAsync(filmDto);

            if(!result.IsValid)
            {
                var errorMessages = result.ResultErrorMessage();

                throw new ValidationProblemException(errorMessages);
            }

            var mapperModel = filmDto.Adapt<Film>();

            _filmRepository.Create(mapperModel);

            await _filmRepository.SaveAsync();

            return filmDto;
        }

        public async Task<FilmDTO> DeleteAsync(Guid id)
        {
            var existingFilm = await _filmRepository.GetByIdAsync(id);

            if(existingFilm is null)
            {
                _logger.LogError("The deletion attempt failed. This id is missing");

                throw new NotFoundException("This id is missing");
            }

            _filmRepository.Delete(existingFilm);

            await _filmRepository.SaveAsync();

            var mapperModel = existingFilm.Adapt<FilmDTO>();

            return mapperModel;
        }

        public async Task<FilmDTO?> GetByIdAsync(Guid id)
        {
            var existingFilm = await _filmRepository.GetByIdAsync(id);

            if(existingFilm is null)
            {
                _logger.LogError("The deletion attempt failed. This id is missing");

                throw new NotFoundException("This id is missing");
            }

            var mappingModel = existingFilm.Adapt<FilmDTO>();

            return mappingModel;
        }

        public async Task<FilmDTO> UpdateAsync(FilmDTO model)
        {
            var existingFilm = await _filmRepository.GetByIdAsync(model.Id);

            if(existingFilm is null)
            {
                _logger.LogError("The updating attempt failed. This id is missing");

                throw new NotFoundException("This id is missing");
            }

            var mapperModel = model.Adapt<Film>();

            _filmRepository.Update(mapperModel);

            await _filmRepository.SaveAsync();

            return model;
        }
    }
}
