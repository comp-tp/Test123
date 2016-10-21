using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.SummaryResponses;

namespace Accela.Apps.Apis.WSModels.RecordSummary
{
    [DataContract(Name = "projectInformationResponse")]
    public class WSProjectInformationResponse : WSResponseBase
    {
        [DataMember(Name = "projectInformations", EmitDefaultValue = false)]
        public List<WSProjectInformation> ProjectInformations { get; set; }

        public static WSProjectInformationResponse FromEntityModel(ProjectInformationResponse response)
        {
            WSProjectInformationResponse result = null;

            if (response != null)
            {
                result = new WSProjectInformationResponse()
                {
                    ProjectInformations = WSProjectInformation.FromEntityModels(response.ProjectInformations)
                };
            }

            return result;
        }
    }
}
