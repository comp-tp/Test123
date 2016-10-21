/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: LicenseProfessionalModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2007-2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: LicenseProfessionalModel4WS.cs 181867 2010-09-30 08:06:18Z ACHIEVO\daly.zeng $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{

    /// <remarks/>
    
    [DataContract]
    
    
    
    public partial class LicenseProfessionalModel4WS
    {

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
        public string busName2 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string businessLicense { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string businessName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CapIDModel4WS capID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string city { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string cityCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string classCode { get; set; }

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
        public string contactType { get; set; }

		/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
		public string contrLicNo { get; set; }

        [DataMember(EmitDefaultValue=false)]
		public string contLicBusName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string country { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string countryCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string createByACA { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string einSs { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string email { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string endbirthDate { get; set; }

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
        public string holdCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string holdDesc { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string lastRenewalDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string lastUpdateDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string licSeqNbr { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string licenseExpirDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string licenseNbr { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string licenseType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string licesnseOrigIssueDate { get; set; }

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
        public string primStatusCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string printFlag { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string relatedTradeLic { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resLicenseType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resState { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string salutation { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string selfIns { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string serDes { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string state { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string suffixName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string workCompExempt { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string zip { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string typeFlag
        { 
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string socialSecurityNumber
        { 
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string maskedSsn
        { 
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string fein
        { 
            get;
            set;
        }
    }
}
