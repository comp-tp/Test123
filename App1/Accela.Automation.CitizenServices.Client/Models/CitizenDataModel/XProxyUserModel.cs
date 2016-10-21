/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: XProxyUserModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: XProxyUserModel.cs 182829 2010-10-20 08:59:58Z ACHIEVO\daly.zeng $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3053")]
    [DataContract]
    
    
    
    public partial class XProxyUserModel : XProxyUserPKModel
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> createdDate { get; set; }     

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> accessDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public SimpleAuditModel auditModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string invitationMessage { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string nickName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public XProxyUserPermissionModel[] XProxyUserPermissionModels { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<ProxyUserStatus> proxyStatus { get; set; }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3053")]
    [DataContract]
    
    public enum ProxyUserStatus
    {

        /// <remarks/>
        P,

        /// <remarks/>
        A,

        /// <remarks/>
        R,

        /// <remarks/>
        E
    }
}
