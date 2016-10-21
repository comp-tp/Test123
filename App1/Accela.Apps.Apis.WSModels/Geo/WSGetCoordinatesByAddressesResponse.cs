using Accela.Apps.Apis.Models.DTOs.Responses.GeoResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Accela.Apps.Apis.WSModels.Geo
{
    [DataContract]
    public class WSGetCoordinatesByAddressesResponse : WSResponseBase
    {
        [DataMember(Name = "locations", EmitDefaultValue = false)]
        public WSGeoLocationListItem[] Locations { get; set; }

        public static WSGetCoordinatesByAddressesResponse FromEntityModel(GeoGetCoordinatesByAddressesResponse model)
        {
            if (model == null)
            {
                return null;
            }

            var result = new WSGetCoordinatesByAddressesResponse();

            if (model.Locations != null && model.Locations.Length > 0)
            {
                var locations = (from m in model.Locations
                                 select new WSGeoLocationListItem()
                                 {
                                     Address = m != null ? m.Address : String.Empty,
                                     Location = new WSGeoLocation()
                                     {
                                         X = m != null && m.Location != null ? m.Location.X.ToString() : "NaN",
                                         Y = m != null && m.Location != null ? m.Location.Y.ToString() : "NaN"
                                     }
                                 }).ToArray();
                result.Locations = locations;
            }

            return result;
        }
    }
}
