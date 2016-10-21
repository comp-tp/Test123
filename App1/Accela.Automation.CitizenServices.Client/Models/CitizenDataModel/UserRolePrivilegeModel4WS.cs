/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: UserRolePrivilegeModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2007-2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: UserRolePrivilegeModel4WS.cs 169604 2010-03-30 09:59:38Z ACHIEVO\daly.zeng $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{

    /// <remarks/>
    
    [DataContract]
    public partial class UserRolePrivilegeModel4WS
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
        public bool licensendProfessionalAllowed { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool ownerAllowed { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool registeredUserAllowed
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public string[] licenseTypeRuleArray 
        {
            get;
            set;
        }
    }
}
