using Accela.Apps.Apis.Models.DTOs.Responses.InspectionResponses;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.WSModels.Inspections
{
    [DataContract(Name = "getWSAvailableInspectionDatesResponse")]
    public class WSAvailableInspectionDatesResponse : WSResponseBase
    {
        [DataMember(Name = "dates")]
        public List<string> Dates
        {
            get;
            set;
        }

        public static WSAvailableInspectionDatesResponse FromEntityModel(AvailableInspectionDatesResponse entityResponse)
        {
            var result = new WSAvailableInspectionDatesResponse();

            if (entityResponse != null
                && entityResponse.Dates != null)
            {
                result.Dates = new List<string>();

                entityResponse.Dates.ForEach(date => result.Dates.Add(date));
            }

            return result;
        }
    }
}
