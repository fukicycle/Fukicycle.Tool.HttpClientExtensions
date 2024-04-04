using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Fukicycle.Tool.HttpClientExtensions
{
    public sealed class HttpResponseResult
    {
        public HttpResponseResult(HttpStatusCode statusCode, string? message, string? jsonBody)
        {
            StatusCode = statusCode;
            Message = message;
            JsonBody = jsonBody;
        }
        public HttpStatusCode StatusCode { get; }
        public string? Message { get; }
        public string? JsonBody { get; }
    }
}
