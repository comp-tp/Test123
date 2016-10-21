using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accela.Apps.Apis.WSModels.ASIs;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.WSModels.Assessments
{
    [DataContract(Name = "wsGetObservationDetailsResponse")]
    public class WSGetObservationDetailsResponse : WSResponseBase
    {
        [DataMember(Name = "observations")]
        public List<WSASITDetail> ASITDetails { get; set; }

        public static WSGetObservationDetailsResponse FromEntityModel(List<WSASIT> wsasits)
        {
            var wsGetObservationDetailsResponse = new WSGetObservationDetailsResponse();

            if (wsasits != null & wsasits.Count > 0)
            {
                wsGetObservationDetailsResponse.ASITDetails = WSASITDetail.FromWSASITs(wsasits);
            }

            return wsGetObservationDetailsResponse;
        }        
    }
}
