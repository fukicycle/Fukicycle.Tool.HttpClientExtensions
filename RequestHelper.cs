using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fukicycle.Tool.HttpClientExtensions
{
    /// <summary>
    /// Helper for requests via http
    /// </summary>
    public sealed class RequestHelper
    {
        private readonly HttpClient _httpClient;
        public RequestHelper(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Sends an HttpRequestMessage with all parameters set and returns the result. As a result, StatusCode, Message, and Body Json are returned.
        /// </summary>
        /// <param name="httpRequestMessage">HttpRequestMessage with all parameters set</param>
        /// <returns>HttpResponseResult</returns>
        public async Task<HttpResponseResult> SendAsync(HttpRequestMessage httpRequestMessage)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string? jsonBody = await httpResponseMessage.Content.ReadAsStringAsync();
                return new HttpResponseResult(System.Net.HttpStatusCode.OK, null, jsonBody);
            }
            else
            {
                string? message = await httpResponseMessage.Content.ReadAsStringAsync();
                return new HttpResponseResult(httpResponseMessage.StatusCode, message, null);
            }
        }
    }
}
