using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.GeoServices.Response
{
    [DataContract(Name = "reverseGeocodeAddress")]
    public class ReverseGeocodeAddress
    {
        [DataMember(Name = "Address")]
        public string Address { get; set; }

        [DataMember(Name = "Neighborhood")]
        public string Neighborhood { get; set; }

        [DataMember(Name="City")]
        public string City { get; set; }

        [DataMember(Name = "Subregion")]
        public string Subregion { get; set; }

        [DataMember(Name = "Region")]
        public string Region { get; set; }

        [DataMember(Name="Postal")]
        public string Postal { get; set; }

        [DataMember(Name = "PostalExt")]
        public string PostalExt { get; set; }

        [DataMember(Name = "CountryCode")]
        public string CountryCode { get; set; }

        #region for custom service

        [DataMember(Name = "Street")]
        public string Street { get; set; }

        [DataMember(Name = "State")]
        public string State { get; set; }

        [DataMember(Name = "ZIP")]
        public string ZIP { get; set; }

        #endregion
    }
}
