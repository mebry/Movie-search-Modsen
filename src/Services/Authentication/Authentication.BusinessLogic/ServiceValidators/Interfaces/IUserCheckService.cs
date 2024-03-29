﻿using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.BusinessLogic.ServiceValidators.Interfaces
{
    public interface IUserCheckService
    {
        Task<User> CheckIfUserExistsAndGetByIdAsync(string userId);
        Task<User> CheckIfUserExistsByUsernameAndGetAsync(string username);


    }
}
