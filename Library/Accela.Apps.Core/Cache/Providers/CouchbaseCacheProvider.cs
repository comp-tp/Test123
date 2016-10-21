using Accela.Apps.Core.Cache.Couchbase;
using Accela.Apps.Core.Cache.Providers;
using Accela.Core.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Apps.Core.Cache.Providers
{
    public sealed class CouchbaseCacheProvider : CacheProviderBase, ICouchbaseProvider
    {
        //private static ICache _cache;
        //static readonly Object _lock = new Object();
        public CouchbaseCacheProvider()
        {
            
        }

        protected internal override ICache GetCache()
        {
            return new CouchbaseCache();
        }   

    }
}
