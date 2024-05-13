using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Shared.DTO
{
    public class GetTechnologyCategoryDTO
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<GetTutorialCategoryItem> CategoryItems { get; set; }
        public int TechnologyId { get; set; }
        public bool IsPublished { get; set; }
        public GetTechnologyCategoryDTO Technology { get; set; }
    }
}
