using System;
using System.Text;
using System.Runtime.Serialization;
using System.Linq;
using System.Collections.Generic;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;

namespace Accela.Apps.Apis.Models.DTOs.Requests.CitizenCommentRequests
{
    [DataContract]
    public class GetCommentRequest : RequestBase
    {
        [DataMember(Name = "globalEntityID", EmitDefaultValue = false)]
        public Guid GlobalEntityID { get; set; }

        [DataMember(Name = "appID", EmitDefaultValue = false)]
        public string AppID { get; set; }
    }
}
