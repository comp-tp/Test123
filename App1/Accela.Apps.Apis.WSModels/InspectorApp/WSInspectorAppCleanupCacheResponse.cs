using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.CommonResponses;

namespace Accela.Apps.Apis.WSModels.InspectorApp
{
    [DataContract(Name = "cleanupCacheResponse")]
    public class WSInspectorAppCleanupCacheResponse
    {
        [DataMember(Name = "returnKey", EmitDefaultValue = false)]
        public string ReturnKey { get; set; }

        public static WSInspectorAppCleanupCacheResponse FromEntityModel(RefreshDataResponse model)
        {
            WSInspectorAppCleanupCacheResponse result = null;

            if (model != null)
            {
                result = new WSInspectorAppCleanupCacheResponse()
                {
                    ReturnKey = model.ReturnKey
                };
            }

            return result;
        }
    }
}
