using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.BusinessLogic.DTOs.ResponseDTOs
{
    public class UserResponseDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
    }
}
