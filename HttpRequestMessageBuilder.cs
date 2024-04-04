using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Fukicycle.Tool.HttpClientExtensions
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class HttpRequestMessageBuilder
    {
        internal readonly HttpRequestMessage _message;
        public HttpRequestMessageBuilder()
        {
            _message = new HttpRequestMessage();
        }

        /// <summary>
        /// Check whether the required parameters are set and return HttpRequestMessage.
        /// </summary>
        /// <returns>HttpRequestMessage</returns>
        /// <exception cref="HttpRequestException">Thrown when EndPoint is not set.</exception>
        /// <exception cref="NotSupportedException">Thrown when the Get method is set and content is set in the Body.</exception>
        public HttpRequestMessage Build()
        {
            if (_message.RequestUri == null)
            {
                throw new HttpRequestException("You have to add request uri. Request uri is Null.");
            }
            if (_message.Method == HttpMethod.Get)
            {
                if (_message.Content != null)
                {
                    throw new NotSupportedException("If you want to contain body in request, you don't have to use 'GET' method.");
                }
            }
            return _message;
        }
    }
}
