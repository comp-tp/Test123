/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: RefDocumentModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: RefDocumentModel.cs 136291 2009-06-25 10:46:10Z ACHIEVO\jackie.yu $.
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
    
    
    
    public partial class RefDocumentModel : LanguageModel
    {
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
        public string comment { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public UserRolePrivilegeModel deleteRolePrivilegeModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string docSeqNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string documentCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string documentType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string isRestrictDocType4ACA { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resDocumentType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string restrictRole4ACA { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string servProvCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public UserRolePrivilegeModel uploadRolePrivilegeModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public UserRolePrivilegeModel viewRolePrivilegeModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public UserRolePrivilegeModel viewTitleRolePrivilegeModel { get; set; }
    }
}
