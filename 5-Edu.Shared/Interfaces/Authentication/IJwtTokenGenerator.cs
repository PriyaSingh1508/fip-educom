using Edu.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Shared.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        public string GenerateToken(UserDetailsDTO user, string roles);
    }
}
