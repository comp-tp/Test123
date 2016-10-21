using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.SummaryModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.SummaryResponses
{
    [DataContract]
    public class ProjectInformationResponse : ResponseBase
    {
        [DataMember(Name = "projectInformations", EmitDefaultValue = false)]
        public List<ProjectInformationModel> ProjectInformations { get; set; }
    }
}
