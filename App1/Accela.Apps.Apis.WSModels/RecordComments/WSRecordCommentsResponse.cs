using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.RecordResponses;

namespace Accela.Apps.Apis.WSModels.RecordComments
{
    [DataContract(Name = "getRecordCommentsResponse")]
    public class WSRecordCommentsResponse : WSPagedResponse
    {
        [DataMember(Name = "comments", EmitDefaultValue = false)]
        public List<WSRecordComment> RecordComments {get; set;}

        public static WSRecordCommentsResponse FromEntityModel(RecordCommentsResponse entityModel)
        {
            if (entityModel == null)
            {
                return new WSRecordCommentsResponse()
                {
                };
            }

            var result = new WSRecordCommentsResponse()
            {
                RecordComments = entityModel.RecordComments == null ? null : WSRecordComment.FromEntityModels(entityModel.RecordComments)  
            };  
            return result;
        }
    }
}
