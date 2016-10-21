#region Header
/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: RefExaminationModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: RefExaminationModel.cs 181867 2011-09-27 08:06:18Z ACHIEVO\daly.zeng $.
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
    
    
    
    public partial class RefExaminationModel : RefExaminationPKModel
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public SimpleAuditModel auditModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string comments { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string examName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string gradingStyle { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string passingScore { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public ProviderModel[] providerModels { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public XRefExaminationAppTypeModel[] refExamAppTypeModels { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public XRefExaminationProviderModel[] refExamProviderModels { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> resId { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string workflowstatus { get; set; }
    }
}
