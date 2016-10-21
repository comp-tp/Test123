/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: TrustAccountPeopleModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: TrustAccountPeopleModel.cs 130107 2009-05-11 12:23:56Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    
    [DataContract]
    
    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://model.webservice.accela.com")]
    public partial class TrustAccountPeopleModel {
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string acctID { get; set; }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> acctNBR { get; set; }
        
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
        public System.Nullable<System.DateTime> birthDate { get; set; }
        
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
        public System.Nullable<System.DateTime> expirationDate { get; set; }
        
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
        public System.Nullable<long> peopleNBR { get; set; }
        
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
        public System.Nullable<System.DateTime> recDate { get; set; }
        
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
