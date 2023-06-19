using Microsoft.EntityFrameworkCore;
using Rating.DataAccess.Entities;
using System.Reflection;

namespace Rating.DataAccess.Contexts
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<RatingFilm> Ratings { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
