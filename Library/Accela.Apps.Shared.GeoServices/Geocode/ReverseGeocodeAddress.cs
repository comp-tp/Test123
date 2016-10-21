using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Accela.Apps.GeoServices
{
    [DataContract]
    public class ReverseGeocodeAddress
    {
        [DataMember]
        public string DetailAddress { get; set; }

        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public string AddressBuilding { get; set; }

        [DataMember]
        public string AddressNumber { get; set; }

        [DataMember]
        public string AddressNumberFrom { get; set; }

        [DataMember]
        public string AddressNumberTo { get; set; }

        [DataMember]
        public string Side { get; set; }

        [DataMember]
        public string StreetPrefixDirection { get; set; }

        [DataMember]
        public string StreetPrefixType { get; set; }

        [DataMember]
        public string StreetName { get; set; }

        [DataMember]
        public string StreetType { get; set; }

        [DataMember]
        public string StreetDirection { get; set; }

        [DataMember]
        public string StreetAddress { get; set; }

        [DataMember]
        public string City { get; set; }

        [DataMember]
        public string State { get; set; }

        [DataMember]
        public string Zip { get; set; }

        [DataMember]
        public string Country { get; set; }

        [DataMember]
        public string CountryCode { get; set; }
    }
}
