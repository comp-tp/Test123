/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: EducationModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2009-2012
 * 
 *  Description:
 *  EducationModel4WS model..
 * 
 *  Notes:
 * $Id: EducationModel4WS.cs 215812 2012-03-17 02:47:41Z ACHIEVO\alan.hu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [DataContract]
    
    
    
    public partial class EducationModel4WS
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public AuditModel4WS auditModel { get; set; }

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
        public EducationPKModel4WS educationPKModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public ProviderDetailModel4WS providerDetailModel { get; set; }

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

        /// <summary>
        /// Row Index
        /// </summary>
        public int RowIndex
        {
            get;
            set;
        }
    }
}
