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
        Task<UserDto> CreateUser(UserForCreationDto user);

        Task<IEnumerable<UserDto>> GetAllUsers();

        Task<UserDto> GetUserById(string id);

        Task AddUserToRole(string userId, string roleId);

        Task DeleteUserByUserId(string userId); 

    }
}
