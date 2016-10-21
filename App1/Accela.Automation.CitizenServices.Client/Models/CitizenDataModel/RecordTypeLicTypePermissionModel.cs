/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: RecordTypeLicTypePermissionModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: RecordTypeLicTypePermissionModel.cs 181867 2010-09-30 08:06:18Z ACHIEVO\daly.zeng $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */

using System;
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [DataContract]
    
    
    
    public partial class RecordTypeLicTypePermissionModel
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string alias { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public SimpleAuditModel auditModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool bizLicExpEnabled4AA { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool bizLicExpEnabled4ACA { get; set; }

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
        public string entityPermission { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> entityPermissionSeq { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string entityType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string group { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool insExpEnabled4AA { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool insExpEnabled4ACA { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CapTypePermissionModel interModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool licExpEnabled4AA { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool licExpEnabled4ACA { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string licType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string moduleName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string serviceProviderCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string subType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string type { get; set; }
    }
}
