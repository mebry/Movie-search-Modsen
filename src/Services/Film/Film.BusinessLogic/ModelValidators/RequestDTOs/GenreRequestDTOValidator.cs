using Film.BusinessLogic.DTOs.RequestDTOs;
using Film.BusinessLogic.DTOs.ResponseDTOs;
using FluentValidation;

namespace Film.BusinessLogic.ModelValidators.RequestDTOs
{
    /// <summary>
    /// Validator for GenreRequestDTO.
    /// </summary>
    public class GenreRequestDTOValidator : AbstractValidator<GenreRequestDTO>
    {
        public GenreRequestDTOValidator()
        {
            RuleFor(genre => genre.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Name is required.")
                .MaximumLength(30)
                .WithMessage("Name must not exceed 30 characters.");
        }
    }
}
