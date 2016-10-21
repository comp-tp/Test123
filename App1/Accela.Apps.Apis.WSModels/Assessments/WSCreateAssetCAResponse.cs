using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.AssessmentResponses;

namespace Accela.Apps.Apis.WSModels.Models.Assessments
{
    [DataContract(Name = "wsCreateAssetCAResponse")]
    public class WSCreateAssetCAResponse : WSResponseBase
    {
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        public static WSCreateAssetCAResponse FromEntityModel(CreateAssetCAResponse createAssetCAResponse)
        {
            var wsCreateAssetCAResponse = new WSCreateAssetCAResponse
            {
                //ResponseStatus = WSSystem.FromEntityModel(createAssetCAResponse)
            };

            if (createAssetCAResponse != null)
            {
                wsCreateAssetCAResponse.Id = createAssetCAResponse.Id;
            }

            return wsCreateAssetCAResponse;
        } 
    }
}
