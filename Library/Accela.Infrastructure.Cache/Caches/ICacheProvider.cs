using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Infrastructure.Caches
{
    public interface ICacheProvider
    {
        ICache Instance { get; }
     
    }


    public interface ILocalCacheProvider : ICacheProvider
    {
        
    }

    public interface IRemoteCacheProvider : ICacheProvider
    {
        
    }

}
