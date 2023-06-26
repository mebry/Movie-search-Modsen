using Microsoft.EntityFrameworkCore;
using Reporting.DataAccess.Contexts;
using Reporting.DataAccess.Entities;

namespace Reporting.DataAccess.Repositories.UserRepository
{
    internal class UserRepository : EFRepository<User>, IUserRepository
    {
        public UserRepository(ReportingContext context) : base(context)
        {
        }

        public override async Task<User?> GetByIdAsync(Guid id)
              => await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == id);
    }
}
}
