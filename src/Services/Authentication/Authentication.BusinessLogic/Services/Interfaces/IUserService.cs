using Authentication.BusinessLogic.DTOs;
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
        Task<UserDto> CreateUserAsync(UserForCreationDto user);

        Task<IEnumerable<UserDto>> GetAllUsersAsync();

        Task<UserDto> GetUserByIdAsync(string id);

        Task AddUserToRoleAsync(string userId, string roleId);

        Task DeleteUserByUserIdAsync(string userId); 

    }
}
