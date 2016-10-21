/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: TrustAccountPeopleModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2007-2009
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: TrustAccountPeopleModel4WS.cs 130107 2009-05-11 12:23:56Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    
    [DataContract]
    
    
    
    public partial class TrustAccountPeopleModel4WS
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string acctID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string acctNBR { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string address1 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string address2 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string address3 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string birthDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string busName2 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string country { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string countryCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string email { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string expirationDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string fax { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string faxCountryCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string firstName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string gender { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string lastName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string licNbr { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string middleName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string peopleNBR { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string peopleType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string phone1 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string phone1CountryCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string phone2 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string phone2CountryCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string postOfficeBox { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string recDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string recFulName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string recStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string salutation { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string servProvCode { get; set; }
    }
    
}
