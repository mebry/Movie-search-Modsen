using Authentication.BusinessLogic.DTOs;
using Authentication.BusinessLogic.Services.Interfaces;
using Authentication.BusinessLogic.ServiceValidators.Interfaces;
using Authentication.BusinessLogic.Exceptions.AlreadyExistsException;
using Authentication.BusinessLogic.Exceptions.BadRequestException;
using DataAccess.Models;
using Microsoft.AspNetCore.Identity;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Authentication.BusinessLogic.Services.Implementations
{
    internal class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserCheckService _userCheckService;
        private readonly IRoleCheckService _roleCheckService;

        public UserService(UserManager<User> userManager,
            IUserCheckService userCheckService,
            IRoleCheckService roleCheckService
            )
        {
            _userManager = userManager;
            _userCheckService = userCheckService;
            _roleCheckService = roleCheckService;
        }

        public async Task AddUserToRole(string userId, string roleId)
        {
            var user = await _userCheckService.CheckIfUserExistsAndGetById(userId);
            var role = await _roleCheckService.CheckIfRoleExistsAndGetById(roleId);
            if (await _userManager.IsInRoleAsync(user, role.Name))
                throw new UserWithGivenRoleAlreadyExistsException();
            await _userManager.AddToRoleAsync(user, role.Name);
        }

        public async Task<UserDto> CreateUser(UserForCreationDto user)
        {
            var mappedUser = user.Adapt<User>();
            var result = await _userManager.CreateAsync(mappedUser);
            if(!result.Succeeded)
            {
                throw new UserInvalidCredentialsBadRequestException(result.Errors.ToList()[0].Description);
            }
            var userToReturn = mappedUser.Adapt<UserDto>();
            return userToReturn;
        }

        public async Task DeleteUserByUserId(string userId)
        {
            var user = await _userCheckService.CheckIfUserExistsAndGetById(userId);
            await _userManager.DeleteAsync(user);
        }

        public async Task<IEnumerable<UserDto>> GetAllUsers()
        {
            var allUsers = await _userManager.Users.AsNoTracking().ToListAsync();
            var mappedUsers = allUsers.Adapt<IEnumerable<UserDto>>();
            return mappedUsers;
        }

        public async Task<UserDto> GetUserById(string id)
        {
            var user = await _userCheckService.CheckIfUserExistsAndGetById(id);
            return user.Adapt<UserDto>();
        }
    }
}
