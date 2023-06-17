﻿using FilmCollection.BusinessLogic.DTOs.RequestDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmCollection.BusinessLogic.Services.Interfaces
{
    public interface IFilmGenreService
    {
        Task CreateFilmGenreAsync(FilmGenreRequestDto filmGenreRequest);
    }
}
