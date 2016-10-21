/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: PublicUserModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2007-2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: PublicUserModel4WS.cs 200500 2011-07-29 09:56:23Z ACHIEVO\daly.zeng $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3053")]
    [DataContract]
    
    
    
    public partial class PublicUserModel4WS
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public TemplateAttributeModel[] templateAttributes { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string address { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string address2 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public RefAddressModel[] addressList { get; set; }

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
        public string cellPhone { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string cellPhoneCountryCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string city { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string cookie { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string country { get; set; }

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
        public string fein { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string firstName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string gender { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string homePhone { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string homePhoneCountryCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public PublicUserModel4WS[] initialUsers { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string lastName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public LicenseModel4WS[] licenseModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string maskedSsn { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string middleName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string needChangePassword { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public OwnerModel[] ownerModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string pager { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public ParcelModel[] parcelList { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string password { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string passwordChangeDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string passwordHint { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string passwordRequestAnswer { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string passwordRequestQuestion { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public PeopleModel4WS[] peopleModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string pobox { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string prefContactChannel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string prefPhone { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public XProxyUserModel proxyUserModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public PublicUserModel4WS[] proxyUsers { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string receiveSMS { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string roleType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string salutation { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string servProvCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string ssn { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string state { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string statusOfV360User { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string userID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string userSeqNum { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string userTitle { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string viadorUrl { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string workPhone { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string workPhoneCountryCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string zip { get; set; }
    }
}
