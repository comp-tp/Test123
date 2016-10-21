#region Header
/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: EducationModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010-2012
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: EducationModel.cs 181867 2010-10-06 08:06:18Z ACHIEVO\daly.zeng $.
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
    
    
    
    public partial class EducationModel
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public SimpleAuditModel auditModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string b1PerId1 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string b1PerId2 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string b1PerId3 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string comments { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string degree { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string educationName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public EducationPKModel educationPKModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public ProviderDetailModel providerDetailModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string providerName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string providerNo { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string requiredFlag { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string yearAttended { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string yearGraduated { get; set; }
    }
}
