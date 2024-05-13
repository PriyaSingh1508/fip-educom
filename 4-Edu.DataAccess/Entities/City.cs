using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.DAL.Entities
{
    public class City
    {
        public int Id { get; set; }
        public int? StateId { get; set; }
        public string? CityName { get; set; }
    }
}
