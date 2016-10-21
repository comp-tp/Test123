using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.GeoServices.Geocode
{
    [DataContract]
    public class ArcGisGeocodingExtent
    {
        [DataMember]
        public double xmin { get; set; }

        [DataMember]
        public double ymin { get; set; }

        [DataMember]
        public double xmax { get; set; }

        [DataMember]
        public double ymax { get; set; }
    }
}
