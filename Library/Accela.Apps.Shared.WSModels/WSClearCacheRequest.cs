using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Apps.Shared.WSModels
{
    [Serializable]
    [DataContract(Name = "clearCacheRequest")]
    public class WSClearCacheRequest
    {
        [DataMember(Name = "cacheKeys")]
        public string[] CacheKeys { get; set; }
    }
}
