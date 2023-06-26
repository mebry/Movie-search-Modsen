using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Messages.AuthenticationMessages
{
    public class CreateUserMessage
    {
        public Guid Id { get; set; }    
        public string Username { get; set; }
    }
}
