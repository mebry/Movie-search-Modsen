using FilmCollection.BusinessLogic.DTOs.RequestDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmCollection.BusinessLogic.Validators.RequestValidators
{
    public class GenreRequestDtoValidator : AbstractValidator<GenreRequestDto>
    {
        public GenreRequestDtoValidator() 
        {
            RuleFor(g => g.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Name is required")
                .MaximumLength(30)
                .WithMessage("Name must not contain more than 30 characters");
        }
    }
}
