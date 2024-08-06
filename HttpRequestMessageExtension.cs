using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Fukicycle.Tool.HttpClientExtensions
{
    /// <summary>
    /// Builder class for creating HttpRequestMessage.
    /// You can add the necessary information in the method chain.
    /// </summary>
    public static class HttpRequestMessageExtension
    {
        /// <summary>
        /// Add EndPoint.
        /// </summary>
        /// <param name="httpRequestMessageBuilder">HttpRequestMessageBuilder</param>
        /// <param name="endpoint">EndPoint</param>
        /// <returns>HttpRequestMessageBuilder</returns>
        public static HttpRequestMessageBuilder AddEndPoint(this HttpRequestMessageBuilder httpRequestMessageBuilder, string endpoint)
        {
            httpRequestMessageBuilder._message.RequestUri = new Uri(endpoint, UriKind.Relative);
            return httpRequestMessageBuilder;
        }

        /// <summary>
        /// Add HttpMethod.
        /// </summary>
        /// <param name="httpRequestMessageBuilder">HttpRequestMessageBuilder</param>
        /// <param name="method">HttpMethod</param>
        /// <returns>HttpRequestMessageBuilder</returns>
        public static HttpRequestMessageBuilder AddHttpMethod(this HttpRequestMessageBuilder httpRequestMessageBuilder, HttpMethod method)
        {
            httpRequestMessageBuilder._message.Method = method;
            return httpRequestMessageBuilder;
        }

        /// <summary>
        /// Add Header.
        /// </summary>
        /// <param name="httpRequestMessageBuilder">HttpRequestMessageBuilder</param>
        /// <param name="header">Header key.</param>
        /// <param name="value">Header value.</param>
        /// <returns>HttpRequestMessageBuilder</returns>
        public static HttpRequestMessageBuilder AddHeader(this HttpRequestMessageBuilder httpRequestMessageBuilder, string header, string value)
        {
            httpRequestMessageBuilder._message.Headers.Add(header, value);
            return httpRequestMessageBuilder;
        }

        /// <summary>
        /// Add authorization header.
        /// </summary>
        /// <param name="httpRequestMessageBuilder">HttpRequestMessageBuilder</param>
        /// <param name="header">Authorization header key.</param>
        /// <param name="value">Authorization header value.</param>
        /// <returns>HttpRequestMessageBuilder</returns>
        public static HttpRequestMessageBuilder AddAuthorizationHeader(this HttpRequestMessageBuilder httpRequestMessageBuilder, string header, string value)
        {
            httpRequestMessageBuilder._message.Headers.Authorization = new AuthenticationHeaderValue(header, value);
            return httpRequestMessageBuilder;
        }

        /// <summary>
        /// Add json object to body.
        /// </summary>
        /// <param name="httpRequestMessageBuilder">HttpRequestMessageBuilder</param>
        /// <param name="body">json body</param>
        /// <returns>HttpRequestMessageBuilder</returns>
        /// <exception cref="InvalidOperationException">Thrown when other content has already been added.</exception>
        public static HttpRequestMessageBuilder AddJsonBody(this HttpRequestMessageBuilder httpRequestMessageBuilder, string body)
        {
            if (httpRequestMessageBuilder._message.Content != null)
            {
                throw new InvalidOperationException($"Content has already been added. Added content type:{httpRequestMessageBuilder._message.Content.Headers.ContentType?.MediaType}");
            }
            HttpContent content = new StringContent(body, Encoding.UTF8, "application/json");
            httpRequestMessageBuilder._message.Content = content;
            return httpRequestMessageBuilder;
        }

        /// <summary>
        /// Add T item object to body.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="httpRequestMessageBuilder">HttpRequestMessageBuilder</param>
        /// <param name="item">item</param>
        /// <returns>HttpRequestMessageBuilder</returns>
        /// <exception cref="InvalidOperationException">Thrown when other content has already been added.</exception>
        public static HttpRequestMessageBuilder AddItemBody<T>(this HttpRequestMessageBuilder httpRequestMessageBuilder, T item)
        {
            if (httpRequestMessageBuilder._message.Content != null)
            {
                throw new InvalidOperationException($"Content has already been added. Added content type:{httpRequestMessageBuilder._message.Content.Headers.ContentType?.MediaType}");
            }
            HttpContent content = new StringContent(System.Text.Json.JsonSerializer.Serialize(item), Encoding.UTF8, "application/json");
            httpRequestMessageBuilder._message.Content = content;
            return httpRequestMessageBuilder;
        }

        /// <summary>
        /// Add T item object to body.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="httpRequestMessageBuilder">HttpRequestMessageBuilder</param>
        /// <param name="item">item</param>
        /// <param name="jsonSerializerOptions">System.Text.Json.JsonSerializerOptions</param>
        /// <returns>HttpRequestMessageBuilder</returns>
        /// <exception cref="InvalidOperationException">wn when other content has already been added.</exception>
        public static HttpRequestMessageBuilder AddItemBody<T>(this HttpRequestMessageBuilder httpRequestMessageBuilder, T item, System.Text.Json.JsonSerializerOptions jsonSerializerOptions)
        {
            if (httpRequestMessageBuilder._message.Content != null)
            {
                throw new InvalidOperationException($"Content has already been added. Added content type:{httpRequestMessageBuilder._message.Content.Headers.ContentType?.MediaType}");
            }
            HttpContent content = new StringContent(System.Text.Json.JsonSerializer.Serialize(item, options: jsonSerializerOptions), Encoding.UTF8, "application/json");
            httpRequestMessageBuilder._message.Content = content;
            return httpRequestMessageBuilder;
        }

        /// <summary>
        /// Add raw http content.
        /// </summary>
        /// <param name="httpRequestMessageBuilder">HttpRequestMessageBuilder</param>
        /// <param name="content">HttpContent</param>
        /// <returns>HttpRequestMessageBuilder</returns>
        /// <exception cref="InvalidOperationException">Thrown when other content has already been added.</exception>
        public static HttpRequestMessageBuilder AddHttpContent(this HttpRequestMessageBuilder httpRequestMessageBuilder, HttpContent content)
        {
            if (httpRequestMessageBuilder._message.Content != null)
            {
                throw new InvalidOperationException($"Content has already been added. Added content type:{httpRequestMessageBuilder._message.Content.Headers.ContentType?.MediaType}");
            }
            httpRequestMessageBuilder._message.Content = content;
            return httpRequestMessageBuilder;
        }
    }
}
