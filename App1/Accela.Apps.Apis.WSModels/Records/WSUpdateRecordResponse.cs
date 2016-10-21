using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.RecordResponses;

namespace Accela.Apps.Apis.WSModels.Records
{    
    [DataContract(Name = "updateRecordResponse")]
    public class WSUpdateRecordResponse : WSResponseBase
    {
        [DataMember(Name = "record")]
        public WSRecord Record { get; set; }

        /// <summary>
        /// Convert UpdateRecordResponse to WSUpdateRecordResponse.
        /// </summary>
        /// <param name="updateRecordResponse">UpdateRecordResponse.</param>
        /// <returns>WSUpdateRecordResponse.</returns>
        public static WSUpdateRecordResponse FromEntityModel(UpdateRecordResponse updateRecordResponse)
        {
            return new WSUpdateRecordResponse
            {
                Record = WSRecord.FromEntityModel(updateRecordResponse.Record)
            };
        }
    }   
}
