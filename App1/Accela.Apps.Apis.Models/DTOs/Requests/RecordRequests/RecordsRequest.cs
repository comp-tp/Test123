using System;
using System.Text;
using System.Runtime.Serialization;
using System.Linq;
using System.Collections.Generic;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;

namespace Accela.Apps.Apis.Models.DTOs.Requests.RecordRequests
{
    [DataContract(Name = "GetRecordRequest")]
    public class RecordsRequest : PageListRequest
    {
        public enum Methods
        {
            GetRecords,
            GetRecordsByIds
        }

        [DataMember(Name = "elements")]
        public List<string> Elements { get; set; }

        [DataMember(Name = "criteria")]
        public RecordCriteria Criteria { get; set; }

        public string Method { get; set; }

        public bool IgnoreCoordinatesSearch { get; set; }
    }
}
