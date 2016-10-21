/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: OwnerModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010-2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: OwnerModel.cs 130107 2009-05-11 12:23:56Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{

    /// <remarks/>
    
    [DataContract]
    
    
    
    public partial class OwnerModel : LanguageModel
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string address { get; set; }

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
        public System.Nullable<System.DateTime> auditDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string city { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string country { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public DuplicatedAPOKeyModel[] duplicatedAPOKeys { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string email { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> eventID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string fax { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string faxCountryCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public NoticeConditionModel hightestCondition { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string isPrimary { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string ivrPinNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string ivrUserNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string mailAddress { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string mailAddress1 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string mailAddress2 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string mailAddress3 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string mailCity { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string mailCountry { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string mailState { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string mailZip { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string mappingDailyOwnerNbr { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public NoticeConditionModel[] noticeConditions { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string ownerFirstName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string ownerFullName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string ownerLastName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string ownerMiddleName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> ownerNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string ownerStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string ownerTitle { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public ParcelInfoModel[] parcelLists { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string phone { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string phoneCountryCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string primary { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resCountry { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> sourceSeqNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string state { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string taxID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public TemplateAttributeModel[] templates { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string UID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string zip { get; set; }
    }
}
