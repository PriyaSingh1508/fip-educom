using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Shared.Service
{
    public static class HttpRequestExtension
    {
        public static string GetHeaderValue(this HttpRequest request, string key)
        {
            string value = string.Empty;
            if (request.Headers.TryGetValue(key, out StringValues values))
            {
                if (values.Count > 0)
                {
                    value= values[0];
                }
            }

            return value;
        }
    }
}
