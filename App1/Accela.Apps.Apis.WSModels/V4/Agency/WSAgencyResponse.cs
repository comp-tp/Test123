using Accela.Apps.Apis.Models.DTOs.Responses.AgencyResponses;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.WSModels.V4
{
    [DataContract]
    public class WSAgencyV4Response : WSResponseBase
    {
        [DataMember(Name = "result", EmitDefaultValue = false)]
        public WSAgencyV4 Agency { get; set; }

        public static WSAgencyV4Response FromEntityModel(AgencyResponse entityResponse)
        {
            WSAgencyV4Response result = new WSAgencyV4Response();

            if (entityResponse != null)
            {
                result.Agency = WSAgencyV4.FromEntityModel(entityResponse.Agency);
            }

            return result;
        }
    }
}
