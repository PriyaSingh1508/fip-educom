using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Shared.DTO
{
    public class GetTechnologyDTO
    {
        public int Id { get; set; }
        public string TechnologyName { get; set; }
        public string ImageUrl { get; set; }
        public bool IsPublished { get; set; }
        public List<GetTechnologyCategoryDTO> Categories { get; set; }
    }
}
