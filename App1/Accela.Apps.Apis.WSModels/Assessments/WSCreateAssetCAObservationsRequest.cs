using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Requests.AssetRequests;
using Accela.Apps.Apis.WSModels.ASIs;


namespace Accela.Apps.Apis.WSModels.Assessments
{
    [DataContract(Name = "wsCreateAssetCAObservationsRequest")]
    public class WSCreateAssetCAObservationsRequest : WSRequestBase
    {
        [DataMember(Name = "observations")]
        public List<WSASIT> Observations { get; set; }
    }
}
