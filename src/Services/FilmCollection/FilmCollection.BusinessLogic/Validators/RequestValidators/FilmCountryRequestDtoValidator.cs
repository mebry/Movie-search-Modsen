using FilmCollection.BusinessLogic.DTOs.RequestDTOs;
using FluentValidation;

namespace FilmCollection.BusinessLogic.Validators.RequestValidators
{
    public class FilmCountryRequestDtoValidator : AbstractValidator<FilmCountryRequestDto>
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
