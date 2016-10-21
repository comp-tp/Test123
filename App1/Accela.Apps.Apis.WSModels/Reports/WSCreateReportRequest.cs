using System.Collections.Generic;

namespace Accela.Apps.Apis.WSModels.Reports
{
    public class WSCreateReportRequest
    {
        public Dictionary<string, string> Parameters { get; set; }

        public string EntityId { get; set; }

        public string EntityType { get; set; }
    }
}
