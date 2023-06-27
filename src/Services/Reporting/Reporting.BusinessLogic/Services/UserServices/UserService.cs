using Mapster;
using Microsoft.Extensions.Logging;
using Reporting.BusinessLogic.DTOs.ConsumerDTOs;
using Reporting.DataAccess.Entities;
using Reporting.DataAccess.Repositories.StaffPersonRepositories;
using Reporting.DataAccess.Repositories.UserRepository;
using Shared.Exceptions;

namespace Reporting.BusinessLogic.Services.UserServices
{
    internal class UserService : IUserDataCaptureService, IUserReportingService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserService> _logger;

        public UserService(IUserRepository userRepository, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task CreateAsync(ConsumerUserDTO entity)
        {
            var mapperModel = entity.Adapt<User>();
            _userRepository.Create(mapperModel);

            await _userRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var existingUser = await _userRepository.GetByIdAsync(id);

            if(existingUser is null)
            {
                _logger.LogError("The user was not found");

                throw new NotFoundException("The user was not found");
            }

            _userRepository.Delete(id);

            await _userRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(ConsumerUserDTO entity)
        {
            var existingUser = await _userRepository.GetByIdAsync(entity.Id);

            if(existingUser is null)
            {
                _logger.LogError("The user was not found");

                throw new NotFoundException("The user was not found");
            }

            entity.Adapt(existingUser);
            _userRepository.Update(existingUser);

            await _userRepository.SaveChangesAsync();
        }
    }
}
