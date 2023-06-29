using Authentication.BusinessLogic.DTOs.RequestDTOs;
using Authentication.BusinessLogic.DTOs.ResponseDTOs;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.BusinessLogic.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserResponseDto> CreateUserAsync(UserRequestDto user);

        Task<IEnumerable<UserResponseDto>> GetAllUsersAsync();

        Task<UserResponseDto> GetUserByIdAsync(string id);

        Task AddUserToRoleAsync(string userId, string roleId);

        Task DeleteUserByUserIdAsync(string userId);
        Task<IEnumerable<RoleResponseDto>> GetUserRolesAsync(string userId);
    }
}
