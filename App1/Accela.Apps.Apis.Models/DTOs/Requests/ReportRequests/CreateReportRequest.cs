using System.Collections.Generic;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;

namespace Accela.Apps.Apis.Models.DTOs.Requests.ReportRequests
{
    public class CreateReportRequest : RequestBase
    {
        public string ReportId { get; set; }

        public string Module { get; set; }

        public Dictionary<string, string> Parameters { get; set; }

        public string EntityId { get; set; }

        public string EntityType { get; set; }
    }
}
