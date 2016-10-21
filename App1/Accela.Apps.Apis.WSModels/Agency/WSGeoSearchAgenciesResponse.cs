using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.GeoResponses;

namespace Accela.Apps.Apis.WSModels.Agency
{
    [DataContract(Name = "geoSearchAgenciesResponse")]
    public class WSGeoSearchAgenciesResponse : WSResponseBase
    {
        [DataMember(Name = "agencies", EmitDefaultValue = false)]
        public List<WSAgency> Agencies { get; set; }

        public static WSGeoSearchAgenciesResponse FromEntityModel(GeoSearchAgenciesResponse response)
        {
            WSGeoSearchAgenciesResponse result = null;

            if (response != null)
            {
                result = new WSGeoSearchAgenciesResponse()
                {
                    Agencies = WSAgency.FromEntitiesModel(response.Agencies)
                };
            }

            return result;
        }
    }
}
