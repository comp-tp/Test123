/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: PeopleModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2007-2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: PeopleModel4WS.cs 210786 2011-12-27 09:54:22Z ACHIEVO\daly.zeng $.
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
    
    
    
    public partial class PeopleModel4WS
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public TemplateAttributeModel[] attributes { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string birthDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string businessName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string comment { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CompactAddressModel4WS compactAddress { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public ContactAddressModel contactAddress { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public ContactAddressModel[] contactAddressList { get; set; }

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

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string endBirthDate { get; set; }

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
        public string firstName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string flag { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string fullName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string gender { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public NoticeConditionModel hightestCondition { get; set; }

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
        public string lastName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string maskedSsn { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string middleName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string namesuffix { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public NoticeConditionModel[] noticeConditions { get; set; }

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
        public string preferredChannel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string preferredChannelString { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string relation { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resContactType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string salutation { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string serviceProviderCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string socialSecurityNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string title { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string tradeName { get; set; }
    }
}
