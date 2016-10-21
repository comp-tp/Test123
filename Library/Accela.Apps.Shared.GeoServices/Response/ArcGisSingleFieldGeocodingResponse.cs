using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Accela.Apps.GeoServices.Geocode;
using Accela.Apps.GeoServices.Response;

namespace Accela.Apps.GeoServices
{
    [DataContract]
    public class ArcGisSingleFieldGeocodingResponse
    {
        [DataMember]
        public ArcGisSpatialReference spatialReference { get; set; }

        [DataMember]
        public ArcGisSingleFieldGeocodingLocation[] locations { get; set; }

        [DataMember(Name = "error")]
        public ESRIError error { get; set; }
    }
}
