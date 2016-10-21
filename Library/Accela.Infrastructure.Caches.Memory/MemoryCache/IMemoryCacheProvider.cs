using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Infrastructure.Caches
{
    /// <summary>
    /// Interface is used to IoC Registration
    /// </summary>
    public interface IMemoryCacheProvider : ILocalCacheProvider
    {
        //ICacheStore GetCacheStore();
        //new ICacheStore Instance { get; }
    }
}
