/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: ParcelModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010-2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: ParcelModel.cs 158744 2009-11-27 03:34:37Z ACHIEVO\daly.zeng $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{

    /// <remarks/>
    
    [DataContract]
    
    
    
    public partial class ParcelModel : LanguageModel
    {/// <remarks/>
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
        public string block { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string book { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CapIDModel capID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string censusTract { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string councilDistrict { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public DuplicatedAPOKeyModel[] duplicatedAPOKeys { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> eventID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<double> exemptValue { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public GISObjectModel[] gisObjectList { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> gisSeqNo { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public NoticeConditionModel hightestCondition { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<double> improvedValue { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string inspectionDistrict { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<double> landValue { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string legalDesc { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string lot { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string mapNo { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string mapRef { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public NoticeConditionModel[] noticeConditions { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string page { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string parcel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<double> parcelArea { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string parcelNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string parcelStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string planArea { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string primaryParcelFlag { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string range { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string[] refAddressTypes { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resSubdivision { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<int> section { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> sourceSeqNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string subdivision { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string supervisorDistrict { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public TemplateAttributeModel[] templates { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string township { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string tract { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string UID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string unmaskedParcelNumber { get; set; }
    }
}
