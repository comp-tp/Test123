using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.StandardChoicesResponses;

namespace Accela.Apps.Apis.WSModels.StandardChoices
{
    [DataContract(Name = "getStandardChoiceResponse")]
    public class WSGetStandardChoicesResponse : WSResponseBase
    {
        [DataMember(Name = "standardChoices", EmitDefaultValue = false)]
        public List<WSStandardChoices> StandardChoices { get; set; }

        public static WSGetStandardChoicesResponse FromEntityModel(StandardChoicesResponse response)
        {
            return new WSGetStandardChoicesResponse()
            {
                StandardChoices = response.StandardChoicesModels == null ? null : WSStandardChoices.FromEntityModels(response.StandardChoicesModels.ToArray()).ToList()
            };
        }
    }
}
