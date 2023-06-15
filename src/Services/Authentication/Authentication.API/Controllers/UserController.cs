using Authentication.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Authentication.BusinessLogic.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Authentication.API.Controllers
{
    [Route("api/v1/users")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
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
        public async Task<IActionResult> CreateUserAsync(UserForCreationDto userForCreationDto)
        {
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
