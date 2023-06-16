using Film.BusinessLogic.DTOs.RequestDTOs;
using FluentValidation;

namespace Film.BusinessLogic.ModelValidators.RequestDTOs
{
    /// <summary>
    /// Validator for StaffPersonPositionRequestDTO.
    /// </summary>
    public class StaffPersonPositionRequestDTOValidator : AbstractValidator<StaffPersonPositionRequestDTO>
    {
        public StaffPersonPositionRequestDTOValidator()
        {
            RuleFor(c => c.FilmId)
                .NotEmpty()
                .WithMessage("The FilmId is required.");

            RuleFor(c => c.PositionId)
                .NotEmpty()
                .WithMessage("The PositionId is required.");

            RuleFor(c => c.StaffPersonId)
                .NotEmpty()
                .WithMessage("The StaffPersonId is required.");
        }
    }
}
