using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.RecordResponses;

namespace Accela.Apps.Apis.WSModels.Records
{
    [DataContract(Name = "CreateRecordResponse")]
    public class WSCreateRecordResponse : WSResponseBase
    {
        [DataMember(Name = "recordId")]
        public WSRecordId RecordId { get; set; }

        /// <summary>
        /// Convert domain CreateRecordResponse model to WSCreateRecordResponse.
        /// </summary>
        /// <param name="createRecordResponse">CreateRecordResponse.</param>
        /// <returns>WSCreateRecordResponse</returns>
        public static WSCreateRecordResponse FromEntityModel(CreateRecordResponse createRecordResponse)
        {
            return new WSCreateRecordResponse()
            {
                RecordId = WSRecordId.FromEntityModel(createRecordResponse.RecordId),
            };
        }
    }
}
