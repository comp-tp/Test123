using Accela.Apps.Apis.Models.DTOs.Responses.InspectionResponses;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.WSModels.Inspections
{
    [DataContract(Name = "cancelInspectionResponse")]
    public class WSCancelInspectionResponse : WSResponseBase
    {
        public static WSCancelInspectionResponse FromEntityModel(CancelInspectionResponse response)
        {
            if (response == null)
            {
                return null;
            }

            var result = new WSCancelInspectionResponse
            {

            };

            return result;
        }
    }
}
