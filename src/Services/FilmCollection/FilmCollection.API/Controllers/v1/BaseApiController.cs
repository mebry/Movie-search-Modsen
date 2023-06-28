using FilmCollection.API.Extensions;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace FilmCollection.API.Controllers.v1
{
    [Route("api/{v:apiversion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    public class BaseApiController : ControllerBase
    {
        private readonly ILogger _logger;

        public BaseApiController(ILogger logger)
        {
            _logger = logger;
        }   
        

        protected IActionResult ProcessInvalidValidationResult(ValidationResult validationResult, string errorMessage)
        {
            validationResult.AddToModelState(ModelState);
            _logger.LogError(errorMessage);
            return BadRequest(ModelState);
        }
    }
}
