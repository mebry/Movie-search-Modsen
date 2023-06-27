using Microsoft.EntityFrameworkCore;
using Staff.DataAccess.Contexts;
using Staff.DataAccess.Entities;
using Staff.DataAccess.Repositories.Interfaces;

namespace Staff.DataAccess.Repositories.Implementations
{
    public class StaffPersonRepository : IStaffPersonRepository
    {
        private readonly StaffsDbContext _dbContext;

        public StaffPersonRepository(StaffsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(StaffPerson staffPerson)
        {
            await _dbContext.Staff.AddAsync(staffPerson);
        }

        public async Task<IEnumerable<StaffPerson>> GetStaffAsync()
        {
            return await _dbContext.Staff
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<StaffPerson> GetStaffPersonByIdAsync(Guid id)
        {
            return await _dbContext.Staff.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Update(StaffPerson staffPerson)
        {
            _dbContext.Staff.Update(staffPerson);
        }
    }
}
