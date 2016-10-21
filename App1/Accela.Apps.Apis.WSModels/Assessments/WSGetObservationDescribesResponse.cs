using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accela.Apps.Apis.WSModels.ASIs;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.WSModels.Assessments
{
    [DataContract(Name = "wsGetObservationDescribes")]
    public class WSGetObservationDescribesResponse : WSResponseBase
    {
        [DataMember(Name = "observations")]
        public List<WSASITDescribe> ASITDescribes { get; set; }

        public static WSGetObservationDescribesResponse FromEntityModel(List<WSASIT> wsasits)
        {
            var wsGetObservationDescribesResponse = new WSGetObservationDescribesResponse();

            if (wsasits != null & wsasits.Count > 0)
            {
                wsGetObservationDescribesResponse.ASITDescribes = WSASITDescribe.FromWSASITs(wsasits);
            }

            return wsGetObservationDescribesResponse;
        }
    }
}
