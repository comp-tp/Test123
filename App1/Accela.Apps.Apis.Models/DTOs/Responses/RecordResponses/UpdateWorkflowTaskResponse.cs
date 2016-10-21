using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DTOs.Responses.RecordResponses
{
    [DataContract(Name = "UpdateWorkflowTaskResponse")]
    public class UpdateWorkflowTaskResponse : ResponseBase
    {
        [DataMember(Name = "recordId")]
        public string RecordId { get; set; }

        [DataMember(Name = "result")]
        public string Result { get; set; }
    }
}
