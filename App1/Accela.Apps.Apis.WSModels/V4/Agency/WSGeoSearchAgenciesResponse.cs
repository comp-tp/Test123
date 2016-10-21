using Accela.Apps.Apis.Models.DTOs.Responses.GeoResponses;
using Accela.Apps.Apis.WSModels.V4;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.WSModels.Agency.V4
{
    [DataContract(Name = "geoSearchAgenciesResponse")]
    public class WSGeoSearchAgenciesV4Response : WSResponseBase
    {
        [DataMember(Name = "agencies", EmitDefaultValue = false)]
        public List<WSAgencyV4> Agencies { get; set; }

        [DataMember(Name = "result", EmitDefaultValue = false)]
        public List<WSAgencyV4> Result { get; set; }

        public static WSGeoSearchAgenciesV4Response FromEntityModel(GeoSearchAgenciesResponse response)
        {
            WSGeoSearchAgenciesV4Response result = null;

            if (response != null)
            {
                result = new WSGeoSearchAgenciesV4Response()
                {
                    Agencies = WSAgencyV4.FromEntitiesModel(response.Agencies)
                };

                result.Result = result.Agencies;
            }

            return result;
        }
    }
}
