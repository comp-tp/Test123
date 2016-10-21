#region Header
/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: DocumentModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010-2012
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: DocumentModel.cs 181867 2010-10-06 08:06:18Z ACHIEVO\daly.zeng $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
#endregion Header
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [DataContract]
    public partial class DocumentModel
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public string acaPermissions { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public System.Nullable<long> actionNo { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public string allowActions { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public string altId { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public string autoDownloadStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public string b1Udf1 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public string b1Udf2 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public string b1Udf3 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public string b1Udf4 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public CapIDModel capID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public string capTypeAlias { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public string categoryByAction { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public string deleteRole { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public UserRolePrivilegeModel deleteRoleModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public string docCategory { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public string docDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public string docDepartment { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public string docDescription { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public string docGroup { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public string docName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public System.Nullable<double> docNumOfSets { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public string docStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public string docStatusDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public string docSybType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public string docType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public string docVersion { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public DocumentContentModel documentContent { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public System.Nullable<long> documentNo { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public string editURL { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public string eleDateTime { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public string eleLocation { get; set; }

        /// <remarks/>
        [DataMember(Name = "entityID")]
        public string entityID { get; set; }

        /// <remarks/>
        [DataMember(Name = "entityType")]
        public string entityType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public string fileDbSchema { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public string fileDbServer { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public string fileDbType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public string fileKey { get; set; }

        /// <remarks/>
        [DataMember(Name = "fileName")]
        public string fileName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public string fileSigned { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public string fileSignedBy { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public string fileSignedDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public System.Nullable<double> fileSize { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public string fileUpLoadBy { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public string fileUpLoadDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public bool history { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public string identifierDisplay { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public System.Nullable<long> inspectionID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public string inspectionType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public string moduleName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public string parcelNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public System.Nullable<long> parentSeqNbr { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public string password { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public string phyDateTime { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public string phyLocation { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public EdmsPolicyModel policy { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public string recDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public string recFulNam { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public string recLock { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public string recSecurity { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public string recStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public System.Nullable<long> refDocumetntNo { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public string refServProvCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public System.Nullable<long> relatedID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public DocumentRelationModel relationModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public string resDocCategory { get; set; }

        /// <remarks/>
        [DataMember(Name = "serviceProviderCode")]
        public string serviceProviderCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public string socComment { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public string source { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public string sourceName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public TemplateModel template { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public string URL { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public string userName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public string viewRole { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public UserRolePrivilegeModel viewRoleModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public string viewTitleRole { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public UserRolePrivilegeModel viewTitleRoleModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public bool viewTitleable { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public bool viewable { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public string virtualFolders { get; set; }
    }
}