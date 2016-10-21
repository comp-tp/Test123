using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.InspectionModels;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;

namespace Accela.Apps.Apis.Models.DTOs.Requests.InspectionRequests
{
    [DataContract(Name = "ReassignInspection")]
    public class ReassignInspectionRequest : RequestBase
    {
        public ReassignInspectionRequest()
        {
            this.Reassign = true;
        }

        [DataMember(Name = "inspection")]
        public InspectionModel Inspection { get; set; }


       // public bool AutoResign { get; set; }

        [DataMember(Name = "reassign")]
        public bool Reassign { get; private set; }
         
    }
}
