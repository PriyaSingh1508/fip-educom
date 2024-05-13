using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Shared.Models
{
    public class RequestModel
    {

        public int Id { get; set; }
        public int ItemsPerPage { get; set; }
        public int PageNo { get; set; } =1;

    
    }
}
