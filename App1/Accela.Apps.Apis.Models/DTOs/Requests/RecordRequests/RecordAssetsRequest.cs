using System;
using System.Text;
using System.Runtime.Serialization;
using System.Linq;
using System.Collections.Generic;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;

namespace Accela.Apps.Apis.Models.DTOs.Requests.RecordRequests
{
    [DataContract(Name = "getRecordAssetssRequest")]
    public class RecordAssetsRequest : RequestBase
    {
        [DataMember(Name = "recordId")]
        public string RecordId { get; set; }
    }
}
