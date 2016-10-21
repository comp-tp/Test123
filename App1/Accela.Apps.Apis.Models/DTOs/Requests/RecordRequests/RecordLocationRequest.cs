using System;
using System.Text;
using System.Runtime.Serialization;
using System.Linq;
using System.Collections.Generic;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;

namespace Accela.Apps.Apis.Models.DTOs.Requests.RecordRequests
{
    [DataContract(Name = "GetRecordLocationRequest")]
    public class RecordLocationRequest : RequestBase
    {
        [DataMember(Name = "criteria")]
        public RecordCriteria Criteria { get; set; }

        [DataMember(Name = "elements")]
        public List<string> Elements { get; set; }
    }
}
