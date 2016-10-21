using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.GeoServices.Response;

namespace Accela.Apps.GeoServices.Geocode
{
    [DataContract(Name = "geocodingResponse")]
    public class GeocodingResponse
    {
        [DataMember(Name="spatialReference")]
        public SpatialReference SpatialReference { get; set; }

        [DataMember(Name="locations")]
        public List<GeocodingAddress> Locations { get; set; }

        [DataMember(Name = "error")]
        public ESRIError Error { get; set; }
        
    }
}
