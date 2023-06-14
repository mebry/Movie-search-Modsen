using DataAccess.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Authentication.BusinessLogic.Exceptions;
using Authentication.BusinessLogic.Exceptions.NotFoundException;
using Authentication.BusinessLogic.ServiceValidators.Interfaces;

namespace Authentication.BusinessLogic.ServiceValidators.Implementations
{
    internal class RoleCheckService : IRoleCheckService
    {
        private readonly RoleManager<Role> _roleManager;

        public RoleCheckService(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<Role> CheckIfRoleExistsAndGetById(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                throw new RoleNotFoundException();
            }
            return role;
        }
    }
}
