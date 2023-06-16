﻿using FilmCollection.DataAccess.Contexts;
using FilmCollection.DataAccess.Models;
using FilmCollection.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmCollection.DataAccess.Repositories.Implementations
{
    internal class FilmCountryRepository : RepositoryBase<FilmCountry>, IFilmCountryRepository
    {
        private readonly FilmCollectionContext _filmCollectionContext;

        public FilmCountryRepository(FilmCollectionContext filmCollectionContext) : base(filmCollectionContext)
        {
            _filmCollectionContext = filmCollectionContext;
        }

        public async Task CreateFilmCountryAsync(FilmCountry filmCountry)
        {
            Create(filmCountry);
            await _filmCollectionContext.SaveChangesAsync();
        }

        public async Task DeleteFilmCountryAsync(FilmCountry filmCountry)
        {
            Delete(filmCountry);
            await _filmCollectionContext.SaveChangesAsync();
        }
    }
}
