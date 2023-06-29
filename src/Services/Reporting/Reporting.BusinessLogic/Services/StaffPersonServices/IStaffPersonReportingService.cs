using Reporting.BusinessLogic.DTOs.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting.BusinessLogic.Services.StaffPersonServices
{
    public interface IStaffPersonReportingService
    {
        public Task<ResponseStaffPersonPositionsInFilms> GetAllPositionsInFIlms(Guid staffPersonId);
    }
}
