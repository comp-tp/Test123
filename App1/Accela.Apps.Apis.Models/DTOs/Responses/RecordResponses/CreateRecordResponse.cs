using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;
using System.Collections.Generic;

namespace Accela.Apps.Apis.Models.DTOs.Responses.RecordResponses
{
    [DataContract]
    public class CreateRecordResponse : ResponseBase
    {
        [DataMember(Name = "recordId")]
        public RecordIdModel RecordId { get; set; }

        public string OpenDate { get; set; }

        public string Status { get; set; }

        public string AssignTo { get; set; }

        public List<string> ImageUrls { get; set; }

    }
}
