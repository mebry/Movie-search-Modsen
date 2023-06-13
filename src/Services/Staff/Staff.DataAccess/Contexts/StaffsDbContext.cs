using Microsoft.EntityFrameworkCore;
using Staff.DataAccess.Entities;

namespace Staff.DataAccess.Contexts
{
    public class StaffsDbContext : DbContext
    {
        public DbSet<StaffPerson> Staff { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<StaffPersonPosition> StaffPersonPositions { get; set; }

    }
}
