using Edu.Shared.Validation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Shared.Models
{
    public class TechImage
    {
        [Required(ErrorMessage = "Name is required")]
        
        public string Name { get; set; }
        [Required(ErrorMessage = "Image File is required")]
        [AllowedFileFormat(".jpg", ".jpeg", ".png")]

        public IFormFile Image { get; set; }
    }
}
