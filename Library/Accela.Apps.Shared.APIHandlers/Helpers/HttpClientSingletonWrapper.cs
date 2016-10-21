using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Apps.Shared.APIHandlers.Helpers
{
    public class HttpClientSingletonWrapper : HttpClient
    {
        private static readonly Lazy<HttpClientSingletonWrapper> Lazy = new Lazy<HttpClientSingletonWrapper>(() => new HttpClientSingletonWrapper());

        public static HttpClientSingletonWrapper Instance { get { return Lazy.Value; } }

        private HttpClientSingletonWrapper()
            : base(new HttpClientHandler
            {
                UseProxy = false
            }, false)
        {
        }
    }
}
