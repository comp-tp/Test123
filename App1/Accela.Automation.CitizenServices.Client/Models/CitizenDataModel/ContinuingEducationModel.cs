#region Header
/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: ContinuingEducationModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010-2012
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: ContinuingEducationModel.cs 181867 2010-10-06 08:06:18Z ACHIEVO\daly.zeng $.
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
    
    
    
    public partial class ContinuingEducationModel
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
        public string className { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string comments { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string contEduName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public ContinuingEducationPKModel continuingEducationPKModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.DateTime dateOfClass { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool dateOfClassSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double finalScore { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool finalScoreSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string gradingStyle { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double hoursCompleted { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool hoursCompletedSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double passingScore { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool passingScoreSpecified { get; set; }

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
    }    
}
