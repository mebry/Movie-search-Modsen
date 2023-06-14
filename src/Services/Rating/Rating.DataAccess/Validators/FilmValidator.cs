﻿using FluentValidation;
using Rating.DataAccess.Entities;

namespace Rating.DataAccess.Validators
{
    public class FilmValidator : AbstractValidator<Film>
    {
        public FilmValidator()
        {
            RuleFor(x => x.AverageRaiting).Must(x => x >= 1);
        }
    }
}
