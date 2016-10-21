using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.GeoServices.Geocode
{
    [DataContract]
    public class ArcGisSpatialReference
    {
        [DataMember]
        public int wkid { get; set; }

        [DataMember]
        public int latestWkid { get; set; }
    }
}
