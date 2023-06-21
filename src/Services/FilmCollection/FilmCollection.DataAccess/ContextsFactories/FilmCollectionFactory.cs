using FilmCollection.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace FilmCollection.DataAccess.ContextsFactories
{
    internal class FilmCollectionFactory : IDesignTimeDbContextFactory<FilmCollectionContext>
    {
        public FilmCollectionContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<FilmCollectionContext>()
                .UseSqlServer(configuration.GetConnectionString("sqlConnection"));

            return new FilmCollectionContext(builder.Options);
        }
    }
}
