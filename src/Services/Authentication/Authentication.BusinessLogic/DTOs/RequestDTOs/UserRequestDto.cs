using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.BusinessLogic.DTOs.RequestDTOs
{
    public class UserRequestDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
