using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Reporting.DataAccess.Entities;
using System.Reflection;

namespace Reporting.DataAccess.Contexts
{
    public class ReportingContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<Film> Films { get; set; }
        public DbSet<FilmCountry> FilmCountries { get; set; }
        public DbSet<FilmGenre> FilmGenres { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<StaffPerson> StaffPeople { get; set; }
        public DbSet<StaffPersonPosition> StaffPersonPositions { get; set; }
        public DbSet<User> Users { get; set; }

        public ReportingContext(DbContextOptions options, IConfiguration configuration)
           : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.AddInboxStateEntity();
            modelBuilder.AddOutboxMessageEntity();
            modelBuilder.AddOutboxStateEntity();
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
