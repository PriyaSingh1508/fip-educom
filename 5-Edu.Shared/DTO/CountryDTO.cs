using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Shared.DTO
{
    public class CountryDTO
    {
        public int Id { get; set; }
        public string? SortName { get; set; }
        public string? Name { get; set; }
        public int PhoneCode { get; set; }
    }
}
