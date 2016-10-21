using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.RecordResponses;

namespace Accela.Apps.Apis.WSModels.Records
{   
    [DataContract(Name = "GetRecordsSearchResponse")]
    public class WSRecordsSearchResponse : WSPagedResponse
    {
        [DataMember(Name = "records", EmitDefaultValue = false, Order = 3)]
        public List<WSRecordWithAddress> Records { get; set; }

        /// <summary>
        /// Convert biz response to service response.
        /// </summary>
        /// <param name="recordsResponse">Records response.</param>
        /// <returns>WS record response.</returns>
        public static WSRecordsSearchResponse FromEntityModel(RecordsResponse recordsResponse)
        {
            var pageInfo = recordsResponse != null ? recordsResponse.PageInfo : null;
            return new WSRecordsSearchResponse()
            {
                Records = GetWSRecords(recordsResponse),
                PageInfo = WSPagination.FromEntityModel(pageInfo)
            };
        }

        /// <summary>
        /// Get ws records.
        /// </summary>
        /// <param name="recordsResponse">Biz records response</param>
        /// <returns>WS record collection.</returns>
        private static List<WSRecordWithAddress> GetWSRecords(RecordsResponse recordsResponse)
        {
            List<WSRecordWithAddress> wsRecords = null;
            if (recordsResponse != null && recordsResponse.Records != null && recordsResponse.Records.Count > 0)
            {
                wsRecords = new List<WSRecordWithAddress>();
                recordsResponse.Records.ForEach(r => wsRecords.Add(WSRecordWithAddress.FromEntityModel(r)));
            }
            return wsRecords;
        }
    }    
}
