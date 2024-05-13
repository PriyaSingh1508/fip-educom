using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.DAL.Entities
{
    public class Country
    {

        public int id { get; set; }
        public string? SortName { get; set; }
        public string? name { get; set; }
        public int phonecode { get; set; }
    }
}
