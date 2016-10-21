using Accela.Infrastructure.Cache.Couchbase;
using Accela.Infrastructure.Caches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Infrastructure.Cache.Couchbase
{
    public sealed class CouchbaseCacheProvider : CacheStoreProvider, ICouchbaseProvider
    {
        //private static ICache _cache;
        //static readonly Object _lock = new Object();
        public CouchbaseCacheProvider()
        {
            
        }

        protected  override ICache GetCacheStore()
        {
            return new CouchbaseCache();
        }   

    }
}
