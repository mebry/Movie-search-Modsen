﻿using FilmCollection.BusinessLogic.DTOs.RequestDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmCollection.BusinessLogic.Validators.RequestValidators
{
    internal class FilmGenreRequestDtoValidator : AbstractValidator<FilmGenreRequestDto>
    {
        public FilmGenreRequestDtoValidator() 
        {
            RuleFor(fg => fg.BaseFilmInfoId)
                .NotNull()
                .NotEmpty()
                .WithMessage("Film id is required");

            RuleFor(fg => fg.GenreId)
                .NotNull()
                .NotEmpty()
                .WithMessage("Genre is required");
                
        }
    }
}
