﻿using FilmCollection.DataAccess.Contexts;
using FilmCollection.DataAccess.Models;
using FilmCollection.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmCollection.DataAccess.Repositories.Implementations
{
    internal class FilmCollectionRepository : RepositoryBase<FilmCollection.DataAccess.Models.FilmCollection>, IFilmCollectionRepository
    {
        private readonly FilmCollectionContext _filmCollectionContext;

        public FilmCollectionRepository(FilmCollectionContext filmCollectionContext)
            : base(filmCollectionContext)
        {
            _filmCollectionContext = filmCollectionContext;
        }   

        public async Task CreateFilmCollectionAsync(Models.FilmCollection filmCollection)
        {
            Create(filmCollection);
            await _filmCollectionContext.SaveChangesAsync();

        }

        public async Task<FilmCollection.DataAccess.Models.FilmCollection> GetFilmCollectionAsync(Guid collectionId, Guid filmBaseInfoId, bool trackChanges)
        {
            return await GetByConditionAsync(fc => fc.CollectionId.Equals(collectionId) && fc.BaseFilmInfoId.Equals(filmBaseInfoId), trackChanges).SingleOrDefaultAsync();
        }

        public async Task DeleteFilmCollectionAsync(Models.FilmCollection filmCollection)
        {
            Delete(filmCollection);
            await _filmCollectionContext.SaveChangesAsync();
        }
    }
}
