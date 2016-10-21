using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.RecordResponses;

namespace Accela.Apps.Apis.WSModels.Records
{
    [DataContract]
    public class WSRecordsGeoSearchCivicResponse : WSPagedResponse
    {
        [DataMember(Name = "records", EmitDefaultValue = false)]
        public List<WSRecordCivicGeo> Records { get; set; }

        public static WSRecordsGeoSearchCivicResponse FromEntityModel(RecordsGeoResponse entityResponse)
        {
            WSRecordsGeoSearchCivicResponse result = new WSRecordsGeoSearchCivicResponse();

            result.PageInfo = WSPagination.FromEntityModel(entityResponse.PageInfo);

            if (entityResponse != null && entityResponse.Records != null)
            {
                result.Records = new List<WSRecordCivicGeo>();

                entityResponse.Records.ForEach(record => result.Records.Add(WSRecordCivicGeo.FromEntityModel(record)));
            }

            return result;
        }
    }
}
