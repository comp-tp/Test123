using System;
using System.Text;
using System.Runtime.Serialization;
using System.Linq;
using System.Collections.Generic;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;

namespace Accela.Apps.Apis.Models.DTOs.Requests.InspectionRequests
{
    [DataContract]
    public class InspectionChecklistRequest : PageListRequest
    {
        [DataMember(Name = "inspectionId")]
        public string InspectionId { get; set; }
    }
}
