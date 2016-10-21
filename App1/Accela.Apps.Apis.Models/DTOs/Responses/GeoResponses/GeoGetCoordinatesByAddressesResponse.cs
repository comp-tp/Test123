using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Accela.Apps.Apis.Models.DTOs.Responses.GeoResponses
{
    [DataContract]
    public class GeoGetCoordinatesByAddressesResponse : ResponseBase
    {
        [DataMember(Name = "locations")]
        public GeoLocationListItem[] Locations { get; set; }
    }
}
