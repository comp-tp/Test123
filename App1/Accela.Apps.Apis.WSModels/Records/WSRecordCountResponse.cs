using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.GlobalEntityResponse;

namespace Accela.Apps.Apis.WSModels.Records
{
    [DataContract(Name = "getRecordCountResponse")]
    public class WSRecordCountResponse : WSResponseBase
    {
        [DataMember(Name = "count")]
        public int Count { get; set; }


        public static WSRecordCountResponse FromEntityModel(GetGlobalEntitiesCountResponse response)
        {
            WSRecordCountResponse result = new WSRecordCountResponse();
            result.Count = response.Count;
            return result;
        }
    }
}
