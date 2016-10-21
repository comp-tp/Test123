using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.GeoServices.Geocode
{
    [DataContract]
    public class ArcGisGeocodingGeometry
    {
        [DataMember]
        public double? x { get; set; }

        [DataMember]
        public double? y { get; set; }
    }
}
