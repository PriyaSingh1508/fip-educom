using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Shared.DTO
{
    public class PaginationParams
    {
        public int ItemsPerPage { get; set; }
        public int PageNo { get; set; } = 1;
        public int Offset => (PageNo - 1) * ItemsPerPage;
    }

}
