using System;
using System.Text;
using System.Runtime.Serialization;
using System.Linq;
using System.Collections.Generic;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;

namespace Accela.Apps.Apis.Models.DTOs.Requests.CitizenCommentRequests
{
    [DataContract]
    public class CreateCommentRequest : RequestBase
    {
        [DataMember(EmitDefaultValue=false)]
        public Guid GlobalEntityID { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string AppID { get; set; } 

        [DataMember(EmitDefaultValue = false)]
        public string Comment { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public Guid CloudUserID { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string CreateBy { get; set; }
    }
}
