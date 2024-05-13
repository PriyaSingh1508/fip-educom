using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Shared.DTO
{
    public class TutorialItemDTO
    {
        public int Id { get; set; }
        public int TechnologyId {  get; set; }
        public int TutorialCategoryId { get; set; }
        
        public string Topic { get; set; }
        public string Description { get; set; }
        public bool IsPublished { get; set; } 
    }
}
