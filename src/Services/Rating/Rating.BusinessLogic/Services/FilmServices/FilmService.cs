using Mapster;
using Microsoft.Extensions.Logging;
using Rating.BusinessLogic.DTOs;
using Rating.BusinessLogic.Exceptions;
using Rating.DataAccess.Entities;
using Rating.DataAccess.Repositories.FilmRepositories;

namespace Rating.BusinessLogic.Services.FilmServices
{
    internal class FilmService : IFilmService
    {
        private readonly IFilmRepository _filmRepository;
        private readonly ILogger<FilmService> _logger;

        public FilmService(IFilmRepository filmRepository, ILogger<FilmService> logger)
        {
            _filmRepository = filmRepository;
            _logger = logger;
        }

        public async Task<FilmDTO> CreateAsync(FilmDTO model)
        {
            var filmChecked = await _filmRepository.GetByIdAsync(model.Id);

            if(filmChecked is not null)
            {
                _logger.LogError("The creation attempt failed. This id is already in use");

                throw new AlreadyExistException("This id is already used");
            }

            var mapperModel = model.Adapt<Film>();

            _filmRepository.Create(mapperModel);

            await _filmRepository.SaveAsync();

            return model;
        }

        public async Task<FilmDTO> DeleteAsync(FilmDTO model)
        {
            var filmChecked = await _filmRepository.GetByIdAsync(model.Id);

            if(filmChecked is null)
            {
                _logger.LogError("The deletion attempt failed. This id is missing");

                throw new NotFoundException("This id is missing");
            }

            _filmRepository.Delete(filmChecked);

            await _filmRepository.SaveAsync();

            return model;
        }

        public async Task<FilmDTO?> GetByIdAsync(Guid id)
        {
            var filmChecked = await _filmRepository.GetByIdAsync(id);

            if(filmChecked is null)
            {
                _logger.LogError("The deletion attempt failed. This id is missing");

                throw new NotFoundException("This id is missing");
            }

            var mappingModel = filmChecked.Adapt<FilmDTO>();

            return mappingModel;
        }

        public async Task<FilmDTO> UpdateAsync(FilmDTO model)
        {
            var filmChecked = await _filmRepository.GetByIdAsync(model.Id);

            if(filmChecked is null)
            {
                _logger.LogError("The updating attempt failed. This id is missing");

                throw new NotFoundException("This id is missing");
            }

            _filmRepository.Update(filmChecked);

            await _filmRepository.SaveAsync();

            return model;
        }
    }
}
