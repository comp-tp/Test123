/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: CapTypePermissionModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: CapTypePermissionModel.cs 181867 2010-09-30 08:06:18Z ACHIEVO\daly.zeng $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */

using System;
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [DataContract]
    
    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://service.webservice.accela.com/")]
    public partial class CapTypePermissionModel : CapTypePermissionPKModel
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string alias { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public SimpleAuditModel auditModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string category { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string controllerType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string entityKey1 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string entityKey2 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string entityKey3 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string entityKey4 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string entityPermission { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string entityType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string group { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string moduleName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string subType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string type { get; set; }
    }
}
