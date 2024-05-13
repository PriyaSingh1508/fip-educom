using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.DAL.Entities
{
    public class StudentEntity
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set;}
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string MobileNumber { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public bool AcceptTerms { get; set; }
        public string Password { get; set; }
    }
}
