using Mapster;
using Microsoft.Extensions.Logging;
using Reviews.BusinessLogic.DTOs;
using Reviews.BusinessLogic.Exceptions;
using Reviews.BusinessLogic.Services.Interfaces;
using Reviews.DataAccess.Entities;
using Reviews.DataAccess.Repositories.Interfaces;

namespace Reviews.BusinessLogic.Services.Implementations
{
    public class CriticService : ICriticService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CriticService> _logger;

        public CriticService(IUnitOfWork unitOfWork, ILogger<CriticService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<ResponseCriticDTO> CreateAsync(RequestCriticDTO critic)
        {
            var id = Guid.NewGuid();
            var mapperCritic = critic.Adapt<Critic>();
            mapperCritic.Id = id;

            await _unitOfWork.CriticRepository.CreateAsync(mapperCritic);
            await _unitOfWork.SaveChangesAsync();

            var resonseModel = mapperCritic.Adapt<ResponseCriticDTO>();

            return resonseModel;
        }

        public async Task<ResponseCriticDTO> GetByIdAsync(Guid id)
        {
            var existingCritic = await _unitOfWork.CriticRepository.GetByIdAsync(id);

            if (existingCritic == null)
            {
                _logger.LogError($"Critic with ID '{id}' not found.");

                throw new NotFoundException("This id was not found");
            }

            var mapperCritic = existingCritic.Adapt<ResponseCriticDTO>();

            return mapperCritic;

        }

        public async Task<ResponseCriticDTO> RemoveCriticAsync(Guid criticId)
        {
            var existingCritic = await _unitOfWork.CriticRepository.GetByIdAsync(criticId);

            if (existingCritic == null)
            {
                _logger.LogError($"Critic with ID '{criticId}' not found.");

                throw new NotFoundException("This id was not found");
            }

            _unitOfWork.CriticRepository.RemoveCritic(existingCritic);

            await _unitOfWork.SaveChangesAsync();

            var responseModel = existingCritic.Adapt<ResponseCriticDTO>();

            return responseModel;
        }

        public async Task<ResponseCriticDTO> UpdateAsync(Guid id, RequestCriticDTO critic)
        {
            var existingCritic = await _unitOfWork.CriticRepository.GetByIdAsync(id);

            if (existingCritic == null)
            {
                _logger.LogError($"Critic with ID '{id}' not found.");

                throw new NotFoundException("This id was not found");
            }

            var mapperCritic = critic.Adapt<Critic>();
            mapperCritic.Id = id;
            _unitOfWork.CriticRepository.Update(mapperCritic);

            await _unitOfWork.SaveChangesAsync();

            var responseModel = mapperCritic.Adapt<ResponseCriticDTO>();

            return responseModel;
        }
    }
}
