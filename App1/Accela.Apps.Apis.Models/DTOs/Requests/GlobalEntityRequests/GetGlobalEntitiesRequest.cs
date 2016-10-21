using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;

namespace Accela.Apps.Apis.Models.DTOs.Requests.GlobalEntityRequests
{
    public class GetGlobalEntitiesRequest : RequestBase
    {
        public string AgencyName { get; set; }

        public string Environment { get; set; }

        public string EntityType { get; set; }

        public Dictionary<string, string> SearchConditions { get; set; }

        public string SortExpression { get; set; }
    }
}
