#region Header
/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: XInspectionTypeCategoryModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010-2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: XInspectionTypeCategoryModel.cs 207115 2011-11-10 03:23:07Z ACHIEVO\daly.zeng $.
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
    
    
    
    public partial class XInspectionTypeCategoryModel
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public SimpleAuditModel auditModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int externalId { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public XInspectionTypeCategoryPKModel refInspectionTypeCategoryPKModel { get; set; }
    }
}
