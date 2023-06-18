﻿using FilmCollection.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FilmCollection.DataAccess.Repositories.Interfaces
{
    public interface IFilmGenreRepository
    {
        Task CreateFilmGenreAsync(FilmGenre filmGenre);

        Task DeleteFilmGenreAsync(FilmGenre filmGenre);
        Task<FilmGenre> GetFilmGenreAsync(Guid baseFilmInfoId, Guid genreId, bool trackChanges);
    }
}