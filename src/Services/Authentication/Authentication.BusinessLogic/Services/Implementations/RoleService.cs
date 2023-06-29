using Authentication.BusinessLogic.DTOs.ResponseDTOs;
using Authentication.BusinessLogic.Services.Interfaces;
using DataAccess.Models;
using MapsterMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Authentication.BusinessLogic.Services.Implementations
{
    internal class RoleService : IRoleService
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly IMapper _mapper;

        public RoleService(RoleManager<Role> roleManager, IMapper mapper) 
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RoleResponseDto>> GetAllRolesAsync()
        {
            var roles = await _roleManager.Roles.AsNoTracking().ToListAsync();
            return  _mapper.Map<IEnumerable<RoleResponseDto>>(roles);
        }
    }
}
