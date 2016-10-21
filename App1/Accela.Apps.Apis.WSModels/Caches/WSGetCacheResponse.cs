using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.PersistedDataModels;

namespace Accela.Apps.Apis.WSModels.Caches
{
    [DataContract(Name = "wsGetCacheResponse")]
    public class WSGetCacheResponse : WSResponseBase
    {
        [DataMember(Name = "caches", EmitDefaultValue = false)]
        public List<WSCache> Caches { get; set; }

        public static WSGetCacheResponse FromEntityModel(List<PersistedDataModel> persistedDataModels)        
        {
            WSGetCacheResponse wsGetCacheResponse = new WSGetCacheResponse();
            if (persistedDataModels != null && persistedDataModels.Count > 0)
            {
                wsGetCacheResponse.Caches = WSCache.FromEntityModels(persistedDataModels);
            }
            return wsGetCacheResponse;
        }
    }
}
