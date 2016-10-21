using System.Collections.Generic;

namespace Accela.Apps.Apis.Models.DTOs.Responses.InspectionResponses
{
    public class AvailableInspectionDatesResponse : ResponseBase
    {
        public List<string> Dates
        {
            get;
            set;
        }
    }
}
