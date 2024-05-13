using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Shared.DTO
{
    public class GetTutorialCategoriesDTO
    {
        public int Id { get; set; }
        public string TutorialCategoryName { get; set; } //HTML-Overview

        public int TechnologyId { get; set; }
        public string TechnologyName { get; set; }

        public bool  IsPublished { get; set; }
    }
}
