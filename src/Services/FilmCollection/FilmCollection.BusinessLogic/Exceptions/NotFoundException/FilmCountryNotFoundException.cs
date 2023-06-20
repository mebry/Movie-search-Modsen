﻿using FilmCollection.DataAccess.Models;
using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmCollection.BusinessLogic.Exceptions.NotFoundException
{
    public class FilmCountryNotFoundException : NotFoundException
    {
        public FilmCountryNotFoundException(Guid baseFilmInfoId, Countries countryId) 
            : base($"The association between base film info with ${baseFilmInfoId} and country with ${countryId} id doesn't exists")
        {
        }
    }
}