using FilmCollection.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FilmCollection.DataAccess.Contexts
{
    internal class FilmCollectionContext : DbContext
    {
        public DbSet<BaseFilmInfo> BaseFilmInfos { get; set; }
        public DbSet<CollectionModel> CollectionModels { get; set; }
        public DbSet<Models.FilmCollection> FilmCollections { get; set; } 
        public DbSet<FilmCountry> FilmCountries { get; set; }
        public DbSet<FilmGenre> FilmGenres { get; set; }
        public DbSet<Genre> Genres { get; set; }    


        public FilmCollectionContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
