using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Requests.AssetRequests;
using Accela.Apps.Apis.WSModels.ASIs;


namespace Accela.Apps.Apis.WSModels.Assessments
{
    [DataContract(Name = "wsUpdateAssetCAObservationsRequest")]
    public class WSUpdateAssetCAObservationsRequest : WSRequestBase
    {
        [DataMember(Name = "asit")]
        public WSASIT ASIT { get; set; }

        //[DataMember(Name = "row")]
        //public WSASIRow row { get; set; }
    }
}
