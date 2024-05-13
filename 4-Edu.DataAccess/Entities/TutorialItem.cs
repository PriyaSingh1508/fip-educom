using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Edu.DAL.Entities
{
    public class TutorialItem
    {
        public int Id { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; }
        public bool IsPublished { get; set; } = false;
        public int TutorialCategoryId { get; set; }
        [JsonIgnore]
        public virtual TutorialCategory TutorialCategory { get; set; }
        
    }
}
