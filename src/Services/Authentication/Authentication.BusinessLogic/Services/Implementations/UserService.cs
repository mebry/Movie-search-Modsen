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
using MapsterMapper;

namespace Authentication.BusinessLogic.Services.Implementations
{
    internal class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserCheckService _userCheckService;
        private readonly IRoleCheckService _roleCheckService;
        private readonly IMapper _mapper;

        public UserService(UserManager<User> userManager,
            IUserCheckService userCheckService,
            IRoleCheckService roleCheckService,
            IMapper mapper
            )
        {
            _userManager = userManager;
            _userCheckService = userCheckService;
            _roleCheckService = roleCheckService;
            _mapper = mapper;
        }

        public async Task AddUserToRoleAsync(string userId, string roleId)
        {
            var user = await _userCheckService.CheckIfUserExistsAndGetByIdAsync(userId);
            var role = await _roleCheckService.CheckIfRoleExistsAndGetByIdAsync(roleId);
            if (await _userManager.IsInRoleAsync(user, role.Name))
                throw new UserWithGivenRoleAlreadyExistsException();
            await _userManager.AddToRoleAsync(user, role.Name);
        }

        public async Task<UserDto> CreateUserAsync(UserForCreationDto user)
        {
            var mappedUser = _mapper.Map<User>(user);
            var result = await _userManager.CreateAsync(mappedUser, user.Password);
            if(!result.Succeeded)
            {
                throw new UserInvalidCredentialsBadRequestException(result.Errors.ToList()[0].Description);
            }
            var userToReturn = _mapper.Map<UserDto>(mappedUser);
            return userToReturn;
        }

        public async Task DeleteUserByUserIdAsync(string userId)
        {
            var user = await _userCheckService.CheckIfUserExistsAndGetByIdAsync(userId);
            await _userManager.DeleteAsync(user);
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var allUsers = await _userManager.Users.AsNoTracking().ToListAsync();
            var mappedUsers = _mapper.Map<IEnumerable<UserDto>>(allUsers);
            return mappedUsers;
        }

        public async Task<UserDto> GetUserByIdAsync(string id)
        {
            var user = await _userCheckService.CheckIfUserExistsAndGetByIdAsync(id);
            return _mapper.Map<UserDto>(user);
        }
    }
}
