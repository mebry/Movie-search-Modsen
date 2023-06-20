using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Reviews.DataAccess.Entities;
using System.Reflection;

namespace Reviews.DataAccess.Contexts
{
    public class ReviewsDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public virtual DbSet<Critic> Critics { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<TypeOfReview> TypesOfReview { get; set; }

        public ReviewsDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
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
