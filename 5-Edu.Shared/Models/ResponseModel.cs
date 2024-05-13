using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Shared.Models
{
    public class ResponseModel<T>
    {
        public HttpStatusCode Status {  get; set; }
        public T? Data { get; set; }
        public int TotalRecords { get; set; } = 0;
        public string? Message { get; set; }
        public bool IsSuccess {  get; set; }
    }
}
