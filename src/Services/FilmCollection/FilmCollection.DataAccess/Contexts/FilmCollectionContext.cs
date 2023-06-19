using FilmCollection.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FilmCollection.DataAccess.Contexts
{
    internal class FilmCollectionContext : DbContext
    {
        public DbSet<BaseFilmInfo> BaseFilmInfos { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<FilmCollection.DataAccess.Models.FilmCollection> filmCollections { get; set; } 
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
