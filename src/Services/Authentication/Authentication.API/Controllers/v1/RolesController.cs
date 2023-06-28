using Authentication.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.API.Controllers.v1
{
    [Route("api/{v:apiversion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService) 
        {
            _roleService = roleService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllRolesAsync()
        {
            var rolesToReturn = await _roleService.GetAllRolesAsync();
            return Ok(rolesToReturn);
        }
    }
}
