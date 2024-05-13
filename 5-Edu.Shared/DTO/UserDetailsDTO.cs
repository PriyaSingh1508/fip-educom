using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Edu.Shared.DTO
{
    public class UserDetailsDTO
    {
        public int Id { get; set; }
         public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? UserRole { get; set; }
        
        public string Password { get; set; } = string.Empty;
        public string? MobileNo { get; set; }

        public DateTime? Dob { get; set; }

        public string? Gender { get; set; }

        public bool? PolicyAgreement { get; set; }
        public string? SubjectSpecialization { get; set; }
        public IEnumerable<AddressDTO> Addresses { get; set; }

       
    }
}
