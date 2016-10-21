#region Header
/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: ProviderModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: ProviderModel.cs 181867 2011-09-27 08:06:18Z ACHIEVO\daly.zeng $.
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
    
    
    
    public partial class ProviderModel : ProviderPKModel
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public SimpleAuditModel auditModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string externalExamURL { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public RProviderLocationModel[] rProviderLocations { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string offerContinuing { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string offerEducation { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string offerExamination { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string providerName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string providerNo { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public RefContinuingEducationModel[] refContinuingEducations { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public RefEducationModel[] refEducations { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public XRefExaminationProviderModel[] xRefExaminationProviders { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public RefExaminationModel[] refExaminations { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public RefLicenseProfessionalModel refLicenseProfessionalModel { get; set; }
    }
}
