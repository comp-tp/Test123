using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.GeoServices.Response
{
    [DataContract]
    public class Attributes
    {
        [DataMember]
        public int ResultID { get; set; }
    }

    [DataContract(Name="geocodingAddress")]
    public class GeocodingAddress
    {
        [DataMember(Name="address")]
        public string Address { get; set; }

        [DataMember(Name="score")]
        public double Score { get; set; }

        [DataMember(Name="location")]
        public Location Location { get; set; }

        [DataMember(Name = "attributes")]
        public Attributes Attributes { get; set; }
    }
}
