using Authentication.BusinessLogic.Services.Interfaces;
using Authentication.BusinessLogic.ServiceValidators.Interfaces;
using Authentication.BusinessLogic.Exceptions.AlreadyExistsException;
using Authentication.BusinessLogic.Exceptions.BadRequestException;
using DataAccess.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MapsterMapper;
using Authentication.BusinessLogic.DTOs.RequestDTOs;
using Authentication.BusinessLogic.DTOs.ResponseDTOs;
using Shared.Messages.AuthenticationMessages;
using MassTransit;
using DataAccess.Contexts;

namespace Authentication.BusinessLogic.Services.Implementations
{
    internal class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IUserCheckService _userCheckService;
        private readonly IRoleCheckService _roleCheckService;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly AuthContext _authContext;

        public UserService(UserManager<User> userManager,
            RoleManager<Role> roleManager,
            IUserCheckService userCheckService,
            IRoleCheckService roleCheckService,
            IMapper mapper,
            IPublishEndpoint publishEndpoint,
            AuthContext authContext
            )
        {
            _userManager = userManager;
            _userCheckService = userCheckService;
            _roleCheckService = roleCheckService;
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
            _authContext = authContext;
            _roleManager = roleManager;
        }

        public async Task AddUserToRoleAsync(string userId, string roleId)
        {
            var user = await _userCheckService.CheckIfUserExistsAndGetByIdAsync(userId);
            var role = await _roleCheckService.CheckIfRoleExistsAndGetByIdAsync(roleId);
            if (await _userManager.IsInRoleAsync(user, role.Name))
                throw new UserWithGivenRoleAlreadyExistsException();
            await _userManager.AddToRoleAsync(user, role.Name);
        }

        public async Task<IEnumerable<RoleResponseDto>> GetUserRolesAsync(string userId)
        {
            var user = await _userCheckService.CheckIfUserExistsAndGetByIdAsync(userId);
            var roleNames = await _userManager.GetRolesAsync(user);
            var rolesWithId = await _roleManager.Roles.AsNoTracking().Where(r => roleNames.Contains(r.Name)).ToListAsync();
            return _mapper.Map<IEnumerable<RoleResponseDto>>(rolesWithId);
        }

        public async Task<UserResponseDto> CreateUserAsync(UserRequestDto user)
        {
            var mappedUser = _mapper.Map<User>(user);
            var result = await _userManager.CreateAsync(mappedUser, user.Password);
            if(!result.Succeeded)
            {
                throw new UserInvalidCredentialsBadRequestException(result.Errors.ToList()[0].Description);
            }
            await _userManager.AddToRoleAsync(mappedUser, "User");
            var messageToPublish = _mapper.Map<CreateUserMessage>(mappedUser);
            await _publishEndpoint.Publish(messageToPublish);
            await _authContext.SaveChangesAsync();
            var userToReturn = _mapper.Map<UserResponseDto>(mappedUser);
            return userToReturn;
        }

        public async Task DeleteUserByUserIdAsync(string userId)
        {
            var user = await _userCheckService.CheckIfUserExistsAndGetByIdAsync(userId);
            await _userManager.DeleteAsync(user);
            var messageToPublish = _mapper.Map<DeleteUserMessage>(user);
            await _publishEndpoint.Publish(messageToPublish);
            await _authContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserResponseDto>> GetAllUsersAsync()
        {
            var allUsers = await _userManager.Users.AsNoTracking().ToListAsync();
            var mappedUsers = _mapper.Map<IEnumerable<UserResponseDto>>(allUsers);
            return mappedUsers;
        }

        public async Task<UserResponseDto> GetUserByIdAsync(string id)
        {
            var user = await _userCheckService.CheckIfUserExistsAndGetByIdAsync(id);
            return _mapper.Map<UserResponseDto>(user);
        }
    }
}
