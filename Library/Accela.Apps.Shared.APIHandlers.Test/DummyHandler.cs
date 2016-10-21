using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Accela.Apps.Shared.APIHandlers.Test
{
    /// <summary>
    /// Dummy handler for internal test purpose
    /// </summary>
    class DummyHandler : DelegatingHandler
    {

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return new TaskFactory<HttpResponseMessage>().StartNew(() => new HttpResponseMessage(HttpStatusCode.OK), cancellationToken);
        }

    }
}
