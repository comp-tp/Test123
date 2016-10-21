#region Header
/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: UserRolePrivilegeModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: UserRolePrivilegeModel.cs 181867 2010-10-06 08:06:18Z ACHIEVO\daly.zeng $.
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
    
    
    
    public partial class UserRolePrivilegeModel
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool allAcaUserAllowed { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool capCreatorAllowed { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool contactAllowed { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string[] licenseTypeRuleArray { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool licensendProfessionalAllowed { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool onCapTypeLevel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool ownerAllowed { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool registeredUserAllowed { get; set; }
    }
}