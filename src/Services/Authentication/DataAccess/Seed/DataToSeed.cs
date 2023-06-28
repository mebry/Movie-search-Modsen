using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Seed
{
    public static class DataToSeed
    {
        public static User GetAdminUserToAdd()
            =>
                new User()
                {
                    Surname = "Padalitsa",
                    Name = "Maxim",
                    UserName = "Admin",

                };


        public static string AdminPassword = "qwe123";
    }
}
