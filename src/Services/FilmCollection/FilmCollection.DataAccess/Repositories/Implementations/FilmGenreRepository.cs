using FilmCollection.DataAccess.Contexts;
using FilmCollection.DataAccess.Models;
using FilmCollection.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmCollection.DataAccess.Repositories.Implementations
{
    internal class FilmGenreRepository : RepositoryBase<FilmGenre>, IFilmGenreRepository
    {
        private readonly FilmCollectionContext _filmCollectionContext;

        public FilmGenreRepository(FilmCollectionContext filmCollectionContext) : base(filmCollectionContext)
        {
            _filmCollectionContext = filmCollectionContext;
        }

        public async Task CreateFilmGenreAsync(FilmGenre filmGenre)
        {
            Create(filmGenre);
            await _filmCollectionContext.SaveChangesAsync();    
        }

        public async Task DeleteFilmGenreAsync(FilmGenre filmGenre)
        {
            Delete(filmGenre);
            await _filmCollectionContext.SaveChangesAsync();
        }
    }
}
