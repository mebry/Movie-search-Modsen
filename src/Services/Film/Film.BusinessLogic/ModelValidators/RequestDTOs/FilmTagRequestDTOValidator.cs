using Film.BusinessLogic.DTOs.RequestDTOs;
using FluentValidation;

namespace Film.BusinessLogic.ModelValidators.RequestDTOs
{
    /// <summary>
    /// Validator for FilmTagRequestDTO.
    /// </summary>
    public class FilmTagRequestDTOValidator : AbstractValidator<FilmTagRequestDTO>
    {
        public FilmTagRequestDTOValidator()
        {
            RuleFor(c => c.FilmId)
                .NotEmpty()
                .WithMessage("The FilmId is required.");

            RuleFor(c => c.TagId)
                .NotEmpty()
                .WithMessage("The TagId is required.");
        }
    }
}
