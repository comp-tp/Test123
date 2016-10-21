using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.GeoServices.Response;

namespace Accela.Apps.GeoServices.Geocode
{
    [DataContract]
    public class ArcGisMultiFieldGeocodingCandidate
    {
        [DataMember]
        public string address { get; set; }

        // there is an issue for below properties when convert empty string "" to double?, as we has not used the property, we comment it now,
        // if we need the value later, please fix the empty string in Json string before doing conversion.

        //[DataMember]
        //public ArcGisGeocodingGeometry location { get; set; }

        //[DataMember]
        //public double? scope { get; set; }

        [DataMember]
        public ArcGisGeocodingAttribute attributes { get; set; }
    }
}
