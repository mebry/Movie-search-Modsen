using Microsoft.EntityFrameworkCore;
using Reviews.DataAccess.Entities;
using System.Reflection;

namespace Reviews.DataAccess.Contexts
{
    public class ReviewsDbContext : DbContext
    {
        public virtual DbSet<Critic> Critics { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<TypeOfReview> TypesOfReview { get; set; }
        public ReviewsDbContext(DbContextOptions<ReviewsDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
