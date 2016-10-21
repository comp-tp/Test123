using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DTOs.Requests.InspectionRequests
{
    [DataContract(Name = "CancelInspection")]
    public class CancelInspectionRequest : RequestBase
    {
        [DataMember(Name = "inspectionId")]
        public string InspectionId { get; set; }
    }
}
