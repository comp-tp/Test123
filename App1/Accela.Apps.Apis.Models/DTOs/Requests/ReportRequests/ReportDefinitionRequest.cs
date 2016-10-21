using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;

namespace Accela.Apps.Apis.Models.DTOs.Requests.ReportRequests
{
    public class ReportDefinitionRequest : RequestBase
    {
        public string ReportId { get; set; }
        public string Module { get; set; }

        public string Language { get; set; }
    }
}
