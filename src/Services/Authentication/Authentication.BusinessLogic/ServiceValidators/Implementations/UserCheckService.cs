using Authentication.BusinessLogic.Exceptions.NotFoundException;
using Authentication.BusinessLogic.ServiceValidators.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.BusinessLogic.ServiceValidators.Implementations
{
    internal class UserCheckService : IUserCheckService
    {
        private readonly UserManager<User> _userManager;

        public UserCheckService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }   

        public async Task<User> CheckIfUserExistsAndGetById(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new UserNotFoundException();
            }
            return user;
        }

        public async Task<User> CheckIfUserExistsByUsernameAndGet(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                throw new UserNotFoundException();
            }
            return user;
        }
    }
}
