using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.InspectionModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.InspectionResponses
{
    [DataContract]
    public class ReassignInspectionResponse : ResponseBase
    {
        [DataMember(Name = "inspection")]
        public InspectionModel Inspection { get; set; }

        [DataMember(Name = "confirmationNumber")]
        public string ConfirmationNumber { get; set; }
       
    }
}
