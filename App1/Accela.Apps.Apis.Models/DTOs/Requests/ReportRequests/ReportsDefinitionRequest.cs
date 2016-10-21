using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;

namespace Accela.Apps.Apis.Models.DTOs.Requests.ReportRequests
{
    public class ReportsDefinitionRequest : RequestBase
    {
        public string Module { get; set; }

        public string Category { get; set; }

        public string Language { get; set; }
    }
}
