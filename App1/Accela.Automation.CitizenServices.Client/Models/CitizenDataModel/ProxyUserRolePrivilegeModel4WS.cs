/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: UserRolePrivilegeModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: ProxyUserRolePrivilegeModel4WS.cs 182829 2010-10-20 08:59:58Z ACHIEVO\daly.zeng $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{

    /// <remarks/>
    
    [DataContract]
    
    
    
    public partial class ProxyUserRolePrivilegeModel4WS
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool viewRecordAllowed
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool createApplicationAllowed
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool renewRecordAllowed
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool manageInspectionsAllowed
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool manageDocumentsAllowed
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool makePaymentsAllowed
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool amendmentAllowed
        {
            get;
            set;
        }
    }
}