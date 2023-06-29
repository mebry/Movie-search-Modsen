using Microsoft.EntityFrameworkCore;
using Reporting.DataAccess.Contexts;
using Reporting.DataAccess.Entities;

namespace Reporting.DataAccess.Repositories.StaffPersonRepositories
{
    internal class StaffPersonRepository : IStaffPersonRepository
    {
        private readonly ReportingContext _context;

        public StaffPersonRepository(ReportingContext context)
        {
            _context = context;
        }

        public void Create(StaffPerson entity)
            => _context.Add(entity);

        public async Task<StaffPerson?> GetByIdAsync(Guid id)
              => await _context.StaffPeople
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == id);

        public void Update(StaffPerson entity)
             => _context.Update(entity);

        public void Delete(Guid id)
        {
            var obj = _context.Users.Find(id);
            _context.Users.Remove(obj!);
        }

        public async Task SaveChangesAsync()
           => await _context.SaveChangesAsync();
    }
}
