using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.AdditionalModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses
{
    [DataContract(Name = "GetAdditionalGroupResponse")]
    public class AdditionalGroupResponse : ResponseBase
    {
        [DataMember(Name = "additionalGroups", EmitDefaultValue = false)]
        public List<AdditionalGroupModel> AdditionalGroups { get; set; }
    }
}
