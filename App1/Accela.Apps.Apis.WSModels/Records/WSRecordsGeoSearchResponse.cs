using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.RecordResponses;

namespace Accela.Apps.Apis.WSModels.Records
{
    [DataContract]
    public class WSRecordsGeoSearchResponse : WSPagedResponse
    {
        [DataMember(Name = "records", EmitDefaultValue = false)]
        public List<WSRecordGeo> Records { get; set; }

        public static WSRecordsGeoSearchResponse FromEntityModel(RecordsGeoResponse entityResponse)
        {
            WSRecordsGeoSearchResponse result = new WSRecordsGeoSearchResponse();

            result.PageInfo = WSPagination.FromEntityModel(entityResponse.PageInfo);

            if (entityResponse != null && entityResponse.Records != null)
            {
                result.Records = new List<WSRecordGeo>();

                entityResponse.Records.ForEach(record => result.Records.Add(WSRecordGeo.FromEntityModel(record)));
            }

            return result;
        }
    }
}
