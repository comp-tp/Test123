using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Requests.RecordRequests;

namespace Accela.Apps.Apis.WSModels.Records
{
    [DataContract(Name = "createRecordRequest")]
    public class WSCreateRecordRequest
    {
        [DataMember(Name = "createRecord", EmitDefaultValue = false)]
        public WSCreateRecord WSCreateRecord
        {
            get;
            set;
        }

        /// <summary>
        /// Convert WSCreateRecordRequest to CreateRecordRequest.
        /// </summary>
        /// <param name="wsCreateRecordRequest">WSCreateRecordRequest.</param>
        /// <param name="createRecordRequest">CreateRecordRequest.</param>
        public static void ToEntityModel(CreateRecordRequest createRecordRequest, WSCreateRecordRequest wsCreateRecordRequest)
        {
            if (wsCreateRecordRequest != null && wsCreateRecordRequest.WSCreateRecord != null)
            {
                createRecordRequest.Record = WSCreateRecord.ToEntityModel(wsCreateRecordRequest.WSCreateRecord);
            }
        }
    }
}
