using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.RecordResponses;

namespace Accela.Apps.Apis.WSModels.Records
{
    [DataContract(Name = "GetRecordsResponse")]
    public class WSRecordsResponse : WSPagedResponse
    {
        [DataMember(Name = "records", EmitDefaultValue = false, Order = 3)]
        public List<WSRecordWithAddress> Records { get; set; }

        /// <summary>
        /// Convert biz response to service response.
        /// </summary>
        /// <param name="recordsResponse">Records response.</param>
        /// <returns>WS record response.</returns>
        public static WSRecordsResponse FromEntityModel(RecordsResponse recordsResponse)
        {
            WSRecordsResponse result = new WSRecordsResponse
            {
                Records = GetWSRecords(recordsResponse),
                PageInfo = WSPagination.FromEntityModel(recordsResponse.PageInfo)
            };

            return result;
        }

        /// <summary>
        /// Get ws records.
        /// </summary>
        /// <param name="recordsResponse">Biz records response</param>
        /// <returns>WS record collection.</returns>
        internal static List<WSRecordWithAddress> GetWSRecords(RecordsResponse recordsResponse)
        {
            List<WSRecordWithAddress> wsRecords = null;
            if (recordsResponse.Records != null && recordsResponse.Records.Count > 0)
            {
                wsRecords = new List<WSRecordWithAddress>();
                recordsResponse.Records.ForEach(r => wsRecords.Add(WSRecordWithAddress.FromEntityModel(r)));
            }
            return wsRecords;
        }       
    }
}
