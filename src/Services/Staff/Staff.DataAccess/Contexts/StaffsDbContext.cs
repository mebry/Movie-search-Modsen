using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Staff.DataAccess.Entities;
using System.Reflection;

namespace Staff.DataAccess.Contexts
{
    public class StaffsDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public virtual DbSet<StaffPerson> Staff { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Film> Films { get; set; }
        public virtual DbSet<StaffPersonPosition> StaffPersonPositions { get; set; }

        public StaffsDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
