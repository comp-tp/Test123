using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.GeoServices.Geocode
{
    [DataContract]
    public class ArcGisGeocodingAttribute
    {
        [DataMember]
        public string Loc_name { get; set; }

        // there is an issue for below property when convert empty string "" to double?, as we has not used the property, we comment it now,
        // if we need the value later, please fix the empty string in Json string before doing conversion.
        //[DataMember]
        //public double? Score { get; set; }

        [DataMember]
        public string Match_addr { get; set; }
        [DataMember]
        public string Addr_type { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public string PlaceName { get; set; }
        [DataMember]
        public string Place_addr { get; set; }
        [DataMember]
        public string Rank { get; set; }
        [DataMember]
        public string AddBldg { get; set; }
        [DataMember]
        public string AddNum { get; set; }
        [DataMember]
        public string AddNumFrom { get; set; }
        [DataMember]
        public string AddNumTo { get; set; }
        [DataMember]
        public string Side { get; set; }
        [DataMember]
        public string StPreDir { get; set; }
        [DataMember]
        public string StPreType { get; set; }
        [DataMember]
        public string StName { get; set; }
        [DataMember]
        public string StType { get; set; }
        [DataMember]
        public string StDir { get; set; }
        [DataMember]
        public string StAddr { get; set; }
        [DataMember]
        public string Nbrhd { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string Subregion { get; set; }
        [DataMember]
        public string Region { get; set; }
        [DataMember]
        public string Postal { get; set; }
        [DataMember]
        public string PostalExt { get; set; }
        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public string LangCode { get; set; }

        // there is an issue for below properties when convert empty string "" to double?, as we has not used the property, we comment it now,
        // if we need the value later, please fix the empty string in Json string before doing conversion.

        //[DataMember]
        //public double? Distance { get; set; }
        //[DataMember]
        //public double? X { get; set; }
        //[DataMember]
        //public double? Y { get; set; }
        //[DataMember]
        //public double? DisplayX { get; set; }
        //[DataMember]
        //public double? DisplayY { get; set; }
        //[DataMember]
        //public double? Xmin { get; set; }
        //[DataMember]
        //public double? Xmax { get; set; }
        //[DataMember]
        //public double? Ymin { get; set; }
        //[DataMember]
        //public double? Ymax { get; set; }
    }
}
