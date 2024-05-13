using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.DAL.Entities
{
    public class State
    {
        public int id { get; set; }
        public int CountryId { get; set; }
        public string? StateName { get; set; }
    }
}
