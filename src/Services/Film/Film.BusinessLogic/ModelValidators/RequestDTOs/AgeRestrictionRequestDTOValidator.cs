using Film.BusinessLogic.DTOs.RequestDTOs;
using FluentValidation;

namespace Film.BusinessLogic.ModelValidators.RequestDTOs
{
    /// <summary>
    /// Validator for AgeRestrictionRequestDTO.
    /// </summary>
    public class AgeRestrictionRequestDTOValidator : AbstractValidator<AgeRestrictionRequestDTO>
    {
        public AgeRestrictionRequestDTOValidator()
        {
            RuleFor(ageRestriction => ageRestriction.Age)
                .GreaterThanOrEqualTo(1)
                .WithMessage("Age must be greater than or equal to 1.")
                .LessThanOrEqualTo(30)
                .WithMessage("Age must be less than or equal to 30.");
        }
    }
}
