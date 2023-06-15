using Film.BusinessLogic.DTOs.RequestDTOs;
using FluentValidation;

namespace Film.BusinessLogic.ModelValidators.RequestDTOs
{
    /// <summary>
    /// Validator for FilmCountryRequestDTO.
    /// </summary>
    public class FilmCountryRequestDTOValidator : AbstractValidator<FilmCountryRequestDTO>
    {
        public FilmCountryRequestDTOValidator()
        {
            RuleFor(c => c.FilmId)
                .NotEmpty()
                .WithMessage("The FilmId is required.");

            RuleFor(c => c.CountryId) 
                .IsInEnum()
                .WithMessage("Invalid country");
        }
    }
}
