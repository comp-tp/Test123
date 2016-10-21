using Accela.Apps.Shared.APIHandlers;
using System;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Accela.Apps.Apis.APIHandlers
{
    /// <summary>
    /// 
    /// </summary>
    public class HomeHandler : DelegatingHandler
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public HomeHandler()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpMessage message = new HttpMessage(request);

            // response home page immediately and doesn't route to next handler
            // idearly it should be done in route configuration, but didn't cofigure it successfully yet.
            if (message.GetAPIRelativePath() == "/" || message.GetAPIRelativePath() == string.Empty)
            {
                var responseMessage = request.CreateResponse();
                responseMessage.Content = new StringContent("It is API Host Server.");
                return responseMessage;
            }
            else
            {
                return await base.SendAsync(request, cancellationToken);
            }
        }

    }
}
