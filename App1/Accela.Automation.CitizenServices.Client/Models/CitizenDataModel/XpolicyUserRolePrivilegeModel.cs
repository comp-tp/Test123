/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: XpolicyUserRolePrivilegeModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: XpolicyUserRolePrivilegeModel.cs 169604 2010-03-30 09:59:38Z ACHIEVO\daly.zeng $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [DataContract]
    
    
    
    public partial class XpolicyUserRolePrivilegeModel : XPolicyModel
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public UserRolePrivilegeModel userRolePrivilegeModel { get; set; }
    }   
    
}
