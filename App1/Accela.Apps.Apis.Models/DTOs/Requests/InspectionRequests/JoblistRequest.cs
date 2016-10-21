using System;
using System.Text;
using System.Runtime.Serialization;
using System.Linq;
using System.Collections.Generic;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;

namespace Accela.Apps.Apis.Models.DTOs.Requests.InspectionRequests
{
    [DataContract]
    public class JoblistRequest : PageListRequest
    {

        public string ScheduleDateFrom { get; set; }

        public string ScheduleDateTo { get; set; }

        public bool FetchInspectionsForAllInspectors { get; set; }

        public List<string> Districts { get; set; }
    }
}
