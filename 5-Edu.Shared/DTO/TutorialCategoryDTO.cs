using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Edu.Shared.DTO
{
    public class TutorialCategoryDTO
    {
        public int TechnologyId { get; set; }  // HTML ID
        public string[] TutorialCategoryName { get; set; } //HTML-Overview

        
       // public IFormFile ImageFile { get; set; }
    }
}
