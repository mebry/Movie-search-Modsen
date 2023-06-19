using FilmCollection.DataAccess.Models;
using FluentValidation;
using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmCollection.BusinessLogic.Validators.RequestValidators
{
    public class FilmCountryRequestDtoValidator : AbstractValidator<FilmCountry>
    {
        public FilmCountryRequestDtoValidator()
        {
            RuleFor(fc => fc.CountryId)
                .NotNull()
                .WithMessage("Country id is required")
                .IsInEnum()
                .WithMessage("Invalid country");

            RuleFor(fc => fc.BaseFilmInfoId)
                .NotNull()
                .NotEmpty()
                .WithMessage("Film id is required");
        }
    }
}
