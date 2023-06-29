using Mapster;
using Microsoft.Extensions.Logging;
using Staff.BusinessLogic.DTOs;
using Staff.BusinessLogic.Exceptions;
using Staff.BusinessLogic.Services.Interfaces;
using Staff.DataAccess.Entities;
using Staff.DataAccess.Repositories.Interfaces;

namespace Staff.BusinessLogic.Services.Implementations
{
    public class FilmService : IFilmService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<FilmService> _logger;
        public FilmService(IUnitOfWork unitOfWork, ILogger<FilmService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<ResponseFilmDTO> CreateAsync(RequestFilmDTO film)
        {
            var id = new Guid();
            var mapperFilm = film.Adapt<Film>();
            mapperFilm.Id = id;
            await _unitOfWork.FilmRepository.CreateAsync(mapperFilm);
            await _unitOfWork.SaveChangesAsync();

            var responseModel = mapperFilm.Adapt<ResponseFilmDTO>();

            return responseModel;
        }

        public async Task<ResponseFilmDTO> GetFilmByIdAsync(Guid id)
        {
            var existingFilm = await _unitOfWork.FilmRepository.GetFilmByIdAsync(id);

            if (existingFilm == null)
            {
                _logger.LogError($"Film with ID '{id}' not found.");

                throw new NotFoundException("This id was not found");
            }

            var mapperFilm = existingFilm.Adapt<ResponseFilmDTO>();

            return mapperFilm;
        }

        public async Task<ResponseFilmDTO> RemoveFilmAsync(Guid id)
        {
            var existingFilm = await _unitOfWork.FilmRepository.GetFilmByIdAsync(id);

            if (existingFilm == null)
            {
                _logger.LogError($"Film with ID '{id}' not found.");

                throw new NotFoundException("This id was not found");
            }

            _unitOfWork.FilmRepository.RemoveFilm(existingFilm);
            await _unitOfWork.SaveChangesAsync();

            var resonseModel = existingFilm.Adapt<ResponseFilmDTO>();

            return resonseModel;
        }

        public async Task<ResponseFilmDTO> UpdateAsync(Guid id, RequestFilmDTO film)
        {
            var existingFilm = await _unitOfWork.FilmRepository.GetFilmByIdAsync(id);

            if (existingFilm == null)
            {
                _logger.LogError($"Film with ID '{id}' not found.");

                throw new NotFoundException("This id was not found");
            }

            film.Adapt(existingFilm);
            //mapperFilm.Id = id;
            _unitOfWork.FilmRepository.Update(existingFilm);
            await _unitOfWork.SaveChangesAsync();

            var resonseModel = existingFilm.Adapt<ResponseFilmDTO>();

            return resonseModel;
        }
    }
}
