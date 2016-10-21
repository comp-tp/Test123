using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.InspectionModels;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;

namespace Accela.Apps.Apis.Models.DTOs.Requests.InspectionRequests
{
    [DataContract]
    public class UpdateInspectionRequest : RequestBase
    {
        [DataMember(Name = "inspection")]
        public InspectionModel Inspection { get; set; }
    }
}
