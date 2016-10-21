/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: PeopleModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010-2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: PeopleModel.cs 170671 2010-04-16 05:52:20Z ACHIEVO\daly.zeng $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.225")]
    [DataContract]
    
    
    
    public partial class PeopleModel : PersonModel
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public object[] attributes { get; set; }

        //System.Nullable<System.DateTime>
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditID { get; set; }

        //System.Nullable<System.DateTime>
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string birthDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string busName2 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string businessName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string comment { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CompactAddressModel compactAddress { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public ContactAddressModel contactAddress { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public ContactAddressModel[] contactAddressLists { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string contactSeqNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string contactType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string contactTypeFlag { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string country { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string countryCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string email { get; set; }

        //System.Nullable<System.DateTime>
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string endBirthDate { get; set; }

        //System.Nullable<System.DateTime>
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string endDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string fax { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string faxCountryCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string fein { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string flag { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string gender { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string holdCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string holdDescription { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string id { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string ivrPinNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string ivrUserNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string maskedSsn { get; set; }

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
        public string phone3 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string phone3CountryCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string postOfficeBox { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<int> preferredChannel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string preferredChannelString { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string relation { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string salutation { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string serviceProviderCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string socialSecurityNumber { get; set; }

        //System.Nullable<System.DateTime>
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string startDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string tradeName { get; set; }
    }
}
