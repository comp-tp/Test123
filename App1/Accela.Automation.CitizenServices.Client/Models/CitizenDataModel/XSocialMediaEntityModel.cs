#region Header

/**
 * <pre>
 *
 *  Accela Citizen Access
 *  File: XSocialMediaEntityModel.cs
 *
 *  Accela, Inc.
 *  Copyright (C): 2012
 *
 *  Description:
 *
 * </pre>
 */
#endregion
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.225")]
    [DataContract]
    
    
    
    public partial class XSocialMediaEntityModel : XSocialMediaEntityPKModel
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public SimpleAuditModel auditModel { get; set; }
    }
}
