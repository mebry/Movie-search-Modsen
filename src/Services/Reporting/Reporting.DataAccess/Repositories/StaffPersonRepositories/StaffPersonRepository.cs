using Microsoft.EntityFrameworkCore;
using Reporting.DataAccess.Contexts;
using Reporting.DataAccess.Entities;

namespace Reporting.DataAccess.Repositories.StaffPersonRepositories
{
    internal class StaffPersonRepository : EFRepository<StaffPerson>, IStaffPersonRepository
    {
        public StaffPersonRepository(ReportingContext context) : base(context)
        {
        }

        public override async Task<StaffPerson?> GetByIdAsync(Guid id)
              => await _context.StaffPeople
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == id);
    }
}
