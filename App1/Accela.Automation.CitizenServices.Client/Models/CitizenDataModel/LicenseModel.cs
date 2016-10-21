/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: LicenseModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: LicenseModel.cs 181867 2010-09-30 08:06:18Z ACHIEVO\daly.zeng $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */

using System;
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SearchLicenseModel))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [DataContract]
    
    
    
    public partial class LicenseModel
    {/// <remarks/>
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
        public System.Nullable<System.DateTime> auditDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> birthDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool bizLicExpired { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string busName2 { get; set; }

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
        public string contLicBusName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string contactFirstName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string contactLastName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string contactMiddleName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> contrLicNo { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string contryCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string country { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string countryCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string degree { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string discipline { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string EMailAddress { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string einSs { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> endbirthDate { get; set; }       

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
        public string gender { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string holdCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string holdDesc { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool insExpired { get; set; }

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
        public bool isTNExpired { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> ivrPinNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool licExpired { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> licOrigIssDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> licSeqNbr { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string licState { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public RecordTypeLicTypePermissionModel licTypePermission { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string licenseBoard { get; set; }

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
        public string licenseStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string licenseType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string maskedSsn { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string permStatusCode { get; set; }

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
        public string providerName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string providerNo { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string pseudoBusName2 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string pseudoBusinessName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string recLocd { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string recSecurity { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resLicenseStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string salutation { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string selfIns { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string serviceProviderCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string socialSecurityNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string state { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string stateLicense { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string statusGroupCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string suffixName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public TemplateModel template { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string title { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string typeFlag { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> wcCancDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> wcEffDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string wcExempt { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> wcExpDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string wcInsCoCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> wcIntentToSuspNtcSentDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string wcPolicyNo { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> wcSuspendDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string zip { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resLicenseType { get; set; }        
    }
}
