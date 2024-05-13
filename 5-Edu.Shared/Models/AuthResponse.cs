using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Shared.Models
{
    public class AuthResponse
    {
        public string Email { get; set; }
        public string Role { get; set; }
        public string JwtToken { get; set; }
        public int ExpiryTime { get; set; }
    }
}
