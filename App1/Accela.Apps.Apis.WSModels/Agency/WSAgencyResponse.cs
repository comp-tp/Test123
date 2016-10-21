using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.AgencyResponses;

namespace Accela.Apps.Apis.WSModels.Agency
{
    [DataContract]
    public class WSAgencyResponse : WSResponseBase
    {
        [DataMember(Name = "agency", EmitDefaultValue = false)]
        public WSAgency Agency { get; set; }

        public static WSAgencyResponse FromEntityModel(AgencyResponse entityResponse)
        {
            WSAgencyResponse result = new WSAgencyResponse();

            if (entityResponse != null)
            {
                result.Agency = WSAgency.FromEntityModel(entityResponse.Agency);
            }

            return result;
        }
    }
}
