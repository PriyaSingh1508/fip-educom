using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Edu.DAL.Entities
{
    public class TutorialCategory
    {

        public int Id { get; set; }

        public string TutorialCategoryName {  get; set; } //HTML-Overview
      
        public bool IsPublished { get; set; } = false;
        public int TechnologyId { get; set; }  // Category ID
        [JsonIgnore]
        public virtual Technology Technology { get; set; }

        [JsonIgnore]
        public virtual IEnumerable<TutorialItem> TutorialItems { get; set; }
        

    }
}
