/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: PageModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2007-2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: ServiceModel4WS.cs 178037 2010-07-30 06:25:12Z ACHIEVO\daly.zeng $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.832")]
    [DataContract]
    
    
    
    public partial class ServiceModel4WS
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string ASIGroupCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string ASISubGroupCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public RefAppSpecInfoFieldModel4WS[] asiFields { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CapTypeModel capType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string[] licProType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string parentServProvCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string recFullName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string recStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string servPorvCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string serviceName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string sourceNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resServiceName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public RecordTypeLicTypePermissionModel4WS[] licTypePermissions
        {
            get;
            set;
        }
    }
}
