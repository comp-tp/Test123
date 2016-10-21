using System.Collections.Generic;
using Accela.Apps.Apis.Models.DTOs.Responses.RecordResponses;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.WSModels.V4
{
    [DataContract]
    public class WSLocationV4Response : WSResponseBase
    {
        [DataMember(Name = "result", EmitDefaultValue = false)]
        public List<WSRecordLocationV4> Locations { get; set; }

        public static WSLocationV4Response FromEntityModel(RecordsLocationResponse response)
        {
            WSLocationV4Response result = new WSLocationV4Response();

            if (response.Locations != null
                && response.Locations.Count > 0)
            {
                result.Locations = new List<WSRecordLocationV4>();

                response.Locations.ForEach(location => result.Locations.Add(WSRecordLocationV4.FromEntityModel(location)));
            }

            return result;
        }
    }
}
