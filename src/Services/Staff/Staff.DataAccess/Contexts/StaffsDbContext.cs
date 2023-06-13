using Microsoft.EntityFrameworkCore;
using Staff.DataAccess.Entities;

namespace Staff.DataAccess.Contexts
{
    public class StaffsDbContext : DbContext
    {
        public virtual DbSet<StaffPerson> Staff { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<StaffPersonPosition> StaffPersonPositions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
