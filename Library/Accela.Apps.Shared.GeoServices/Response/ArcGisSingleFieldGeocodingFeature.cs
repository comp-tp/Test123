using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.GeoServices.Geocode
{
    [DataContract]
    public class ArcGisSingleFieldGeocodingFeature
    {
        [DataMember]
        public ArcGisGeocodingGeometry geometry { get; set; }

        [DataMember]
        public ArcGisGeocodingAttribute attributes { get; set; }
    }
}
