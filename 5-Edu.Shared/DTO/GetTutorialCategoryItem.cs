using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Shared.DTO
{
    public class GetTutorialCategoryItem
    {
        public int Id { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public bool IsPublished { get; set; }
        public GetTechnologyCategoryDTO Category { get; set; }
    }
}
