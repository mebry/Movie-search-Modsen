using Authentication.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using Authentication.BusinessLogic.DTOs.RequestDTOs;
using FluentValidation.Results;
using FluentValidation;
using Authentication.API.Extensions;

namespace Authentication.API.Controllers.v1
{
    [Route("api/{v:apiversion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IValidator<UserRequestDto> _validator;

        public UsersController(IValidator<UserRequestDto> validator, IUserService userService)
        {
            _userService = userService;
            _validator = validator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUsersAsync()
        {
            var usersToReturn = await _userService.GetAllUsersAsync();
            return Ok(usersToReturn);
        }

        [HttpGet("{userId}", Name = "UserById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserAsync(string userId)
        {
            var userToReturn = await _userService.GetUserByIdAsync(userId);
            return Ok(userToReturn);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateUserAsync(UserRequestDto userForCreationDto)
        {
            ValidationResult result = await _validator.ValidateAsync(userForCreationDto);
            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
                return BadRequest(ModelState);
            }
            var createdUser = await _userService.CreateUserAsync(userForCreationDto);
            return CreatedAtRoute("UserById", new { userId = createdUser.Id }, createdUser);

        }

        [HttpPost("{userId}/roles/{roleId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddToRoleAsync([FromRoute] string userId, [FromRoute] string roleId)
        {
            await _userService.AddUserToRoleAsync(userId, roleId);
            return Ok();
        }

        [HttpGet("{userId}/roles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserRolesAsync(string userId)
        {
            var rolesToReturn = await _userService.GetUserRolesAsync(userId);
            return Ok(rolesToReturn);
        }

        [HttpDelete("{userId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteUserAsync(string userId)
        {
            await _userService.DeleteUserByUserIdAsync(userId);
            return NoContent();
        }
    }
}
