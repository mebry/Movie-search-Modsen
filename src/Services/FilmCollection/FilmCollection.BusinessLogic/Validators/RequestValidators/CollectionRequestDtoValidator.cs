using FilmCollection.BusinessLogic.DTOs.RequestDTOs;
using FilmCollection.DataAccess.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmCollection.BusinessLogic.Validators.RequestValidators
{
    public class CollectionRequestDtoValidator : AbstractValidator<CollectionRequestDto>
    {
        public CollectionRequestDtoValidator() 
        {
            RuleFor(c => c.Title)
                .MaximumLength(300)
                .WithMessage("Title must not contain more than 300 characters");

            RuleFor(c => c.Description)
                .MaximumLength(400)
                .WithMessage("Description must not contain more than 400 characters");
        }
    }
}
