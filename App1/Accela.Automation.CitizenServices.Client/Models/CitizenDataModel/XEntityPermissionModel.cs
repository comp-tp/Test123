#region Header
/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: XEntityPermissionModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: CommentModel.cs 181867 2010-10-06 08:06:18Z ACHIEVO\daly.zeng $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
#endregion Header
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.225")]
    [DataContract]
    
    
    
    public partial class XEntityPermissionModel : XEntityPermissionModelPKModel
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string data1 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string data2 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string entityId { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string entityId2 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string entityId3 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string entityType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string permissionType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string permissionValue { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> recDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string recFulNam { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string recStatus { get; set; }
    }
}
