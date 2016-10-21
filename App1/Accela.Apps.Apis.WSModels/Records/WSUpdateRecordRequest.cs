using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Requests.RecordRequests;

namespace Accela.Apps.Apis.WSModels.Records
{
    [DataContract(Name = "updateRecordRequest")]
    public class WSUpdateRecordRequest
    {
        [DataMember(Name = "updateRecord", EmitDefaultValue = false)]
        public WSUpdateRecord Record { get; set; }

        public static UpdateRecordRequest ToEntityModel(WSUpdateRecordRequest request)
        {
            var result = new UpdateRecordRequest()
            {
                Record = request != null ? WSUpdateRecord.ToEntityModel(request.Record) : null
            };

            return result;
        }
    }
}
