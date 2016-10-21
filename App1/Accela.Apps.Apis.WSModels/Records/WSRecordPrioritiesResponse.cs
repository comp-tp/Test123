using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses;

namespace Accela.Apps.Apis.WSModels.Records
{
    [DataContract]
    public class WSRecordPrioritiesResponse : WSResponseBase
    {
        [DataMember(Name = "priorities", EmitDefaultValue = false, Order = 3)]
        public List<WSRecordPriority> Priorities { get; set; }

        public static WSRecordPrioritiesResponse FromEntityModel(RecordPrioritiesResponse entityResponse)
        {
            WSRecordPrioritiesResponse response = new WSRecordPrioritiesResponse();

            if (entityResponse != null
                && entityResponse.Priorities != null
                && entityResponse.Priorities.Count > 0)
            {
                response.Priorities = new List<WSRecordPriority>();

                foreach (var priority in entityResponse.Priorities)
                {
                    response.Priorities.Add(new WSRecordPriority { Id = priority.Id, Display = priority.Display });
                }
            }

            return response;
        }
    }
}
