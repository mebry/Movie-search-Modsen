using Film.BusinessLogic.DTOs.RequestDTOs;
using Film.BusinessLogic.DTOs.ResponseDTOs;
using FluentValidation;

namespace Film.BusinessLogic.ModelValidators.RequestDTOs
{
    /// <summary>
    /// Validator for StaffPersonRequestDTO.
    /// </summary>
    public class StaffPersonRequestDTOValidator : AbstractValidator<StaffPersonRequestDTO>
    {
        public StaffPersonRequestDTOValidator()
        {
            RuleFor(staff => staff.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Name is required.")
                .MaximumLength(50)
                .WithMessage("Name must not exceed 50 characters.");

            RuleFor(staff => staff.Surname)
                .NotNull()
                .NotEmpty()
                .WithMessage("Surname is required.")
                .MaximumLength(50)
                .WithMessage("Surname must not exceed 50 characters.");
        }
    }
}
