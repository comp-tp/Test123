using System;
using System.Text;
using System.Runtime.Serialization;
using System.Linq;
using System.Collections.Generic;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;

namespace Accela.Apps.Apis.Models.DTOs.Requests.RecordRequests
{
    [DataContract(Name = "dailyRecordsCountRequest")]
    public class DailyRecordsCountRequest : RequestBase
    {
        [DataMember(Name = "recordType")]
        public string RecordType { get; set; }

        [DataMember(Name = "module")]
        public List<string> Modules { get; set; }

        [DataMember(Name = "dateFrom")]
        public string DateFrom { get; set; }

        [DataMember(Name = "dateTo")]
        public string DateTo { get; set; }

        [DataMember(Name = "returnType")]
        public string ReturnType { get; set; }
    }
}
