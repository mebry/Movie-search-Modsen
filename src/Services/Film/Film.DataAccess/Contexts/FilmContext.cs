using Film.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Reflection;

namespace Film.DataAccess.Contexts
{
    /// <summary>
    /// Represents the database context for managing films and related entities.
    /// </summary>
    public class FilmContext : DbContext
    {
        public FilmContext(DbContextOptions<FilmContext> options) : base(options)
        {
        }

        /// <summary>
        /// Represents the relationship between films and countries.
        /// </summary>
        public DbSet<FilmCountry> FilmCountries { get; set; }

        /// <summary>
        /// Represents the films in the database.
        /// </summary>
        public DbSet<FilmModel> Films { get; set; }

        /// <summary>
        /// Represents the genres of films.
        /// </summary>
        public DbSet<Genre> Genres { get; set; }

        /// <summary>
        /// Represents the relationship between films and genres.
        /// </summary>
        public DbSet<FilmGenre> FilmGenres { get; set; }

        /// <summary>
        /// Represents the tags associated with films.
        /// </summary>
        public DbSet<Tag> Tags { get; set; }

        /// <summary>
        /// Represents the relationship between films and tags.
        /// </summary>
        public DbSet<FilmTag> FilmTags { get; set; }

        /// <summary>
        /// Represents the age restrictions for films.
        /// </summary>
        public DbSet<AgeRestriction> AgeRestrictions { get; set; }

        /// <summary>
        /// Represents the positions in the film industry.
        /// </summary>
        public DbSet<Position> Positions { get; set; }

        /// <summary>
        /// Represents the staff members associated with films.
        /// </summary>
        public DbSet<StaffPerson> StaffPersons { get; set; }

        /// <summary>
        /// Represents the relationship between staff persons, positions and films
        /// </summary>
        public DbSet<StaffPersonPosition> StaffPersonPositions { get; set; }

        /// <summary>
        /// Configures the model using the specified modelBuilder.
        /// </summary>
        /// <param name="modelBuilder">The modelBuilder to apply configurations.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
