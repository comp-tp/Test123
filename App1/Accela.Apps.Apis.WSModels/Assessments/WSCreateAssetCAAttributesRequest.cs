using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Requests.AssetRequests;
using Accela.Apps.Apis.WSModels.ASIs;


namespace Accela.Apps.Apis.WSModels.Assessments
{
    [DataContract(Name = "wsCreateAssetCAAttributesRequest")]
    public class WSCreateAssetCAAttributesRequest : WSRequestBase
    {
        [DataMember(Name = "attributes")]
        public List<WSASI> Attributes { get; set; }
    }
}
