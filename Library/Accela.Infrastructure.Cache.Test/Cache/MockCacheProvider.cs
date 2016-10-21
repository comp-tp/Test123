using Accela.Infrastructure.Caches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Apps.Core.Tests.Ioc
{
    public class MockCacheProvider : CacheStoreProvider, IRemoteCacheProvider
    {
        protected override ICache GetCacheStore()
        {
            throw new NotImplementedException();
        }

        ICache ICacheProvider.Instance
        {
            get { throw new NotImplementedException(); }
        }
    }
}
