using Accela.Infrastructure.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Infrastructure.Azure.Storage
{
    public class AzureBinaryStorageProvider : IBinaryStorageProvider
    {
        public IBinaryStorage GetClient(string storageConnectionString, IRetryPolicy retryPolicy)
        {
            return new AzureBinaryStorage(storageConnectionString, retryPolicy);
        }
    }
}
