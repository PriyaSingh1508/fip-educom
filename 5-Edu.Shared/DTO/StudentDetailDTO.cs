using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Shared.DTO
{
    public class StudentDetailDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Lastname is required")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string? Email { get; set; }
        
        public string? UserRole { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [MinLength(8, ErrorMessage = "Password must be atleast 8 characters long")]

        public string Password { get; set; } = string.Empty;
        [Required(ErrorMessage = "MobileNumber is required")]
        public string? MobileNo { get; set; }

        public DateTime? Dob { get; set; }

        public string? Gender { get; set; }

        public bool? PolicyAgreement { get; set; }
          
        public IEnumerable<AddressDTO> Addresses { get; set; }

    }
}
