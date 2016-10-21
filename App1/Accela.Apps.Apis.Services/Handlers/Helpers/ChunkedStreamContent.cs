using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Apps.Apis.Services.Handlers.Helpers
{
    internal class ChunkedStreamContent : StreamContent
    {
        public ChunkedStreamContent(Stream stream)
                : base(stream) { }

        protected override bool TryComputeLength(out long length)
        {
            length = 0L;
            return false;
        }
        
    }
}
