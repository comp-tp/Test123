using System.Collections.Generic;

namespace Accela.Apps.Apis.Repositories.Agency.AARESTModels
{
    public class AACreateReportRequest
    {
        public Dictionary<string, string> parameters { get; set; }

        public string entityId { get; set; }

        public string entityType { get; set; }
    }
}
