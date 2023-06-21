using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FilmCollection.API.Extensions
{
    public static class ValidationExtension
    {
        public static void AddToModelState(this ValidationResult result, ModelStateDictionary modelState)
        {
            foreach(var error in result.Errors)
            {
                modelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
        }
    }
}
