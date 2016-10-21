using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.RecordResponses
{
    [DataContract(Name = "getRecordCommentsResponse")]
    public class RecordCommentsResponse : ResponseBase
    {
        /// <summary>
        /// The record comments information.
        /// </summary>
        [DataMember(Name = "recordComment", EmitDefaultValue = false)]
        public List<RecordCommentModel> RecordComments { get; set; }
      
    }
}
