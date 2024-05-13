using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.DAL.Entities
{
    public class Technology
    {
        public int Id { get; set; }
        public string TechnologyName {  get; set; } //HTML
        public string ImageUrl { get; set; }   //Image
        public bool IsPublished { get; set; } = false;
        public virtual IEnumerable<TutorialCategory> TutorialCategory { get; set; }
    }
}
