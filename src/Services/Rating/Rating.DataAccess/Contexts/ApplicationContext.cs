using Microsoft.EntityFrameworkCore;
using Rating.DataAccess.Entities;

namespace Rating.DataAccess.Contexts
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<Raiting> Raitings { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }
    }
}
