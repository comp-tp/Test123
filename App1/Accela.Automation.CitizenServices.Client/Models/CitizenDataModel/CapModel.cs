#region Header
/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: CapModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010-2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: CapModel.cs 181867 2010-10-06 08:06:18Z ACHIEVO\daly.zeng $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
#endregion Header
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3053")]
    [DataContract]
    
    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://service.webservice.accela.com/")]
    public partial class CapModel : CapPage4ACAModel
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string activeTasks { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string activeTasksStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public AddressModel addressModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public object[] addtionalItems { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string altID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public object[] appAddressModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public object[] appRefDocumentModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public object[] appSpecificInfoGroups { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string appTypeAlias { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CapContactModel applicantModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public TemplateAttributeModel assetArributeModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public object[] assetList { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public AssetMasterModel assetMasterModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.DateTime auditDate { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool auditDateSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public B1ExpirationModel b1ExpirationModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public BCalcValuatnModel[] BCalcValuationList { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public BStructureModel BStructureModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public BValuatnModel BValuatnModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string basedOn { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string capClass { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CapContactModel capContactModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CapDetailModel capDetailModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CapIDModel capID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public RefOwnerModel[] capOwnerList { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public OwnerModel capOwnerModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public ParcelModel capParcelModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string capStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.DateTime capStatusDate { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool capStatusDateSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CapTypeModel capType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CapWorkDesModel capWorkDesModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string checkBoxComment { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public ContinuingEducationModel[] contEducationList { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public object[] contactsGroup { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public object[] costingList { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CostingModel costingModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public EducationModel[] educationList { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.DateTime endFileDate { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool endFileDateSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.DateTime endReportedDate { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool endReportedDateSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public StructureEstablishmentModel[] establishmentList { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string eventCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public ExaminationModel[] examinationList { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.DateTime fileDate { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool fileDateSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public TaskItemModel historyTaskItemModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string initiatedProduct { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string isManualAltID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool isSuperAgency { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool isSuperAgencySpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string licSeqNbr { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public LicenseProfessionalModel[] licenseProfessionalList { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public LicenseProfessionalModel licenseProfessionalModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string moduleName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public OwnerModel[] ownerList { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public RefOwnerModel ownerModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public ParcelModel[] parcelList { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CapParcelModel parcelModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CapIDModel parentCapID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public PartTransactionModel partModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string processCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public ProjectModel projectModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long projectNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string QUD1 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string QUD2 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string QUD3 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string QUD4 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string receiptNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public RefAddressModel[] refAddressList { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public RefAddressModel refAddressModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string refID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string refID1 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string refID2 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string refID3 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.DateTime reportedDate { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool reportedDateSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string reportedTime { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public SectionTownShipRangeModel sectionTownShipRangeModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string setID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string source { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public object[] specialInfo { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string specialText { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string standardPCClass { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double standardPCTime { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string statusGroupCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public StructureEstablishmentModel[] structureList { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string superServProvCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public SysUserModel sysUser { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public TaskItemModel taskItemModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public TaskSpecificInfoModel[] taskSpecInfos { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long trackingNbr { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool useManualAltID { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool useManualAltIDSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public object[] userDefineParcelAttributes { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public XAssetTypeCapTypeModel[] XAssetTypeCapTypeList { get; set; }
    }
}
