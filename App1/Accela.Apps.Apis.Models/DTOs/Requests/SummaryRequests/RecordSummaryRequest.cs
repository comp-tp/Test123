using System;
using System.Text;
using System.Runtime.Serialization;
using System.Linq;
using System.Collections.Generic;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;

namespace Accela.Apps.Apis.Models.DTOs.Requests.SummaryRequests
{
    [DataContract]
    public class RecordSummaryRequest : RequestBase
    {
        [DataMember(Name = "recordId", EmitDefaultValue = false)]
        public string RecordId { get; set; }
    }
}
