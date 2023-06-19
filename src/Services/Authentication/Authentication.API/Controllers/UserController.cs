using Authentication.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using Authentication.BusinessLogic.DTOs.RequestDTOs;
using FluentValidation.Results;
using FluentValidation;
using Authentication.API.Extensions;

namespace Authentication.API.Controllers
{
    [Route("api/v1/users")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IValidator<UserRequestDto> _validator;

        public UserController(IValidator<UserRequestDto> validator, IUserService userService)
        {
            _userService = userService;
            _validator = validator;
        }   

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetUsersAsync()
        {
            var usersToReturn  = await _userService.GetAllUsersAsync();
            return Ok(usersToReturn);   
        }

        [HttpGet("{userId}", Name = "UserById")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetUserAsync(string userId)
        {
            var userToReturn = await _userService.GetUserByIdAsync(userId);
            return Ok(userToReturn);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
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
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddToRoleAsync([FromRoute]string userId, [FromRoute] string roleId)
        {
            await _userService.AddUserToRoleAsync(userId, roleId);
            return Ok();    
        }

        
        [HttpDelete("{userId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteUserAsync(string userId)
        {
            await _userService.DeleteUserByUserIdAsync(userId);
            return NoContent();
        }
    }
}
