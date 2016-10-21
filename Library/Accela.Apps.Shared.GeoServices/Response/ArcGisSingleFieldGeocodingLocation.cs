using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.GeoServices.Geocode
{
    [DataContract]
    public class ArcGisSingleFieldGeocodingLocation
    {
        [DataMember]
        public string name { get; set; }

        [DataMember]
        public ArcGisGeocodingExtent extent { get; set; }

        [DataMember]
        public ArcGisSingleFieldGeocodingFeature feature { get; set; }
    }
}
