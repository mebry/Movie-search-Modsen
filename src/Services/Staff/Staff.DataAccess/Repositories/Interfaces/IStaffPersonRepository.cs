using Staff.DataAccess.Entities;

namespace Staff.DataAccess.Repositories.Interfaces
{
    public interface IStaffPersonRepository
    {
        public Task<IEnumerable<StaffPerson>> GetStaffAsync();
        public Task<StaffPerson> GetStaffPersonByIdAsync(Guid id);
        public Task CreateAsync(StaffPerson staffPerson);
        public void Update(StaffPerson staffPerson);

    }
}
