using Film.BusinessLogic.DTOs.RequestDTOs;
using FluentValidation;

namespace Film.BusinessLogic.ModelValidators.RequestDTOs
{
    /// <summary>
    /// Validator for FilmGenreRequestDTO.
    /// </summary>
    public class FilmGenreRequestDTOValidator : AbstractValidator<FilmGenreRequestDTO>
    {
        public FilmGenreRequestDTOValidator()
        {
            RuleFor(c => c.FilmId)
                .NotEmpty()
                .WithMessage("The FilmId is required.");

            RuleFor(c => c.GenreId)
                .NotEmpty()
                .WithMessage("The GenreId is required.");
        }
    }
}
