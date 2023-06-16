using Authentication.BusinessLogic.DTOs.RequestDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.BusinessLogic.Validators.RequestValidators
{
    public class UserRequestValidator : AbstractValidator<UserRequestDto>
    {
        public UserRequestValidator() 
        {
            RuleFor(user => user.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Name is required")
                .MaximumLength(50)
                .WithMessage("Name must be 50 letters or fewer");

            RuleFor(user => user.Surname)
                .NotNull()
                .NotEmpty()
                .WithMessage("Surname is required")
                .MaximumLength(50)
                .WithMessage("Surname must be 50 letters or fewer");
        }
    }
}
