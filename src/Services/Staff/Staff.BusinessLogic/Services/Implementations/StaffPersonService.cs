using Mapster;
using Microsoft.Extensions.Logging;
using Staff.BusinessLogic.DTOs;
using Staff.BusinessLogic.Exceptions;
using Staff.BusinessLogic.Services.Interfaces;
using Staff.DataAccess.Entities;
using Staff.DataAccess.Repositories.Interfaces;

namespace Staff.BusinessLogic.Services.Implementations
{
    public class StaffPersonService : IStaffPersonService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<StaffPersonService> _logger;

        public StaffPersonService(IUnitOfWork unitOfWork, ILogger<StaffPersonService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<ResponseStaffPersonDTO> CreateAsync(RequestStaffPersonDTO staffPerson)
        {
            var id = new Guid();
            var mapperStaffPerson = staffPerson.Adapt<StaffPerson>();
            mapperStaffPerson.Id = id;

            await _unitOfWork.StaffPersonRepository.CreateAsync(mapperStaffPerson);
            await _unitOfWork.SaveChangesAsync();

            var responseModel = mapperStaffPerson.Adapt<ResponseStaffPersonDTO>();

            return responseModel;
        }

        public async Task<IEnumerable<ResponseStaffPersonDTO>> GetStaffAsync()
        {
            var staff = await _unitOfWork.StaffPersonRepository.GetStaffAsync();

            if (staff.Count() == 0)
            {
                _logger.LogError("Can't get all staff persons, there is no data");

                throw new NotFoundException("There is no data");
            }

            var staffPersons = staff.Adapt<IEnumerable<ResponseStaffPersonDTO>>();

            return staffPersons;
        }

        public async Task<ResponseStaffPersonDTO> GetStaffPersonByIdAsync(Guid id)
        {
            var existingStaffPerson = await _unitOfWork.StaffPersonRepository.GetStaffPersonByIdAsync(id);

            if (existingStaffPerson == null)
            {
                _logger.LogError($"Staff person with ID '{id}' not found.");

                throw new NotFoundException("This id was not found");
            }

            var mapperStaffPerson = existingStaffPerson.Adapt<ResponseStaffPersonDTO>();

            return mapperStaffPerson;
        }

        public async Task<ResponseStaffPersonDTO> UpdateAsync(Guid id, RequestStaffPersonDTO staffPerson)
        {
            var existingStaffPerson = await _unitOfWork.StaffPersonRepository.GetStaffPersonByIdAsync(id);

            if (existingStaffPerson == null)
            {
                _logger.LogError($"Staff person with ID '{id}' not found.");

                throw new NotFoundException("This id was not found");
            }

            var mapperStaffPerson = staffPerson.Adapt<StaffPerson>();
            mapperStaffPerson.Id = id;
            _unitOfWork.StaffPersonRepository.Update(mapperStaffPerson);
            await _unitOfWork.SaveChangesAsync();

            var responseModel = mapperStaffPerson.Adapt<ResponseStaffPersonDTO>();

            return responseModel;
        }
    }
}
