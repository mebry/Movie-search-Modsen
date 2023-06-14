using Authentication.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Authentication.BusinessLogic.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Authentication.API.Controllers
{
    [Route("api/[controller]")]
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
        public async Task<IActionResult> GetUsers()
        {
            var usersToReturn  = await _userService.GetAllUsers();
            return Ok(usersToReturn);   
        }

        [HttpGet("{id:string}", Name = "UserById")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetUser(string userId)
        {
            var userToReturn = await _userService.GetUserById(userId);
            return Ok(userToReturn);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateUser(UserForCreationDto userForCreationDto)
        {
            var createdUser = await _userService.CreateUser(userForCreationDto);
            return CreatedAtRoute("UserById", new { userId = createdUser.Id }, createdUser);

        }

        [HttpPost("{userId:string}/roles/{roleId:string}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddToRole([FromRoute]string userId, [FromRoute] string roleId)
        {
            await _userService.AddUserToRole(userId, roleId);
            return Ok();    
        }

        
        [HttpDelete("{id:string}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            await _userService.DeleteUserByUserId(userId);
            return NoContent();
        }
    }
}
