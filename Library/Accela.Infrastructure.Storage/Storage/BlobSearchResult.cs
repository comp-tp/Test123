using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Infrastructure.Storage
{
    public class BlobSearchResult
    {
        public IEnumerable<BlobProperties> Results;

        public string ContinuationToken;
    }
}
