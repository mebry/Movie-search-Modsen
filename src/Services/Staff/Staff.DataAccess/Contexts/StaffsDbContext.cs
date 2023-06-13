using Microsoft.EntityFrameworkCore;
using Staff.DataAccess.Entities;
using System.Reflection;

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
            //Применит все конфигурации, определенные в текущей сборке. EF Core будет автоматически искать все классы, реализующие IEntityTypeConfiguration<T>,
            //в текущей сборке и применять их конфигурации.
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
