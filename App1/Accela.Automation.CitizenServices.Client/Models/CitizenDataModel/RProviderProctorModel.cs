#region Header
/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: RProviderProctorModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: ExaminationModel.cs 181867 2010-10-06 08:06:18Z ACHIEVO\daly.zeng $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
#endregion Header
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [DataContract]
    
    
    
    public partial class RProviderProctorModel
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string address { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public SimpleAuditModel auditModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string email { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string name { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string phone { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string phoneCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public RProviderProctorPKModel proctorPKModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> providerNbr { get; set; }
    }
}
