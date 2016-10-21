#region Header
/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: RefLicenseProfessionalModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: RefLicenseProfessionalModel.cs 181867 2011-09-27 08:06:18Z ACHIEVO\daly.zeng $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
#endregion Header
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [DataContract]
    
    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://service.webservice.accela.com/")]
    public partial class RefLicenseProfessionalModel
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string acaPermission { get; set; }

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
        public string agencyCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public SimpleAuditModel auditModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> birthDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> businessLicExpDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string businessLicense { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string businessName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string city { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string cityCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string comment { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public ContactModel contact { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string country { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string countyCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string email { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string fax { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string faxCountryCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string gender { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public RefLicenseProfessionalPKModel id { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<double> insuranceAmount { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string insuranceCo { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> insuranceExpDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> ivrPinNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string licState { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> licenseExpirationDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> licenseIssueDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> licenseLastRenewalDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string licenseType { get; set; }

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
        public string policy { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string postOfficeBox { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string salutation { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string state { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string stateLicense { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string title { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string udf1 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string udf2 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string udf3 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string udf4 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string zip { get; set; }
    }
}
