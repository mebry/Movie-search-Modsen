using Film.BusinessLogic.DTOs.RequestDTOs;
using Film.BusinessLogic.DTOs.ResponseDTOs;
using FluentValidation;

namespace Film.BusinessLogic.ModelValidators.RequestDTOs
{
    /// <summary>
    /// Validator for PositionRequestDTO.
    /// </summary>
    public class PositionRequestDTOValidator : AbstractValidator<PositionRequestDTO>
    {
        public PositionRequestDTOValidator()
        {
            RuleFor(position => position.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Name is required.")
                .MaximumLength(50)
                .WithMessage("Name must not exceed 50 characters.");
        }
    }
}
