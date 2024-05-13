using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Shared.DTO
{
    public class AddressDTO
    {
        public string? Country { get; set; }
        public string? State { get; set; }

        public string? City { get; set; }

        public int ZipCode { get; set; }

        public string? Street { get; set; }
    }
}
