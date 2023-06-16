using Film.BusinessLogic.DTOs.RequestDTOs;
using FluentValidation;

namespace Film.BusinessLogic.ModelValidators.RequestDTOs
{
    /// <summary>
    /// Validator for TagRequestDTO.
    /// </summary>
    public class TagRequestDTOValidator : AbstractValidator<TagRequestDTO>
    {
        public TagRequestDTOValidator()
        {
            RuleFor(tag => tag.Name) 
                .NotNull()
                .NotEmpty()
                .WithMessage("Name is required.")
                .MaximumLength(30)
                .WithMessage("Name must not exceed 30 characters.");
        }
    }
}
