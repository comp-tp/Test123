using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.SummaryModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.SummaryResponses
{
    [DataContract]
    public class ContactSummaryResponse : ResponseBase
    {
        [DataMember(Name = "contactSummaries", EmitDefaultValue = false)]
        public List<ContactSummaryModel> ContactSummaries { get; set; }
    }
}
