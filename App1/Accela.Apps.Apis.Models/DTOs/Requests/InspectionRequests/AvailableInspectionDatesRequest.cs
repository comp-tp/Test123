using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;

namespace Accela.Apps.Apis.Models.DTOs.Requests.InspectionRequests
{
    public class AvailableInspectionDatesRequest : RequestBase
    {
        public string InspectionTypeId { get; set; }

        public string RecordId { get; set; }

        public string StartDate { get; set; }

        public int DatesCount { get; set; }
    }
}
