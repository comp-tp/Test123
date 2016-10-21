using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.RecordResponses;
using Accela.Apps.Apis.WSModels.Location;

namespace Accela.Apps.Apis.WSModels.RecordLocation
{
    [DataContract]
    public class WSLocationResponse : WSPagedResponse
    {
        [DataMember(Name = "location", EmitDefaultValue = false)]
        public WSLocation Location { get; set; }

        public static WSLocationResponse FromEntityModel(RecordLocationResponse response)
        {
            return new WSLocationResponse()
            {
                Location = WSLocation.FromEntityModel(response.Location),
            };
        }
    }
}
