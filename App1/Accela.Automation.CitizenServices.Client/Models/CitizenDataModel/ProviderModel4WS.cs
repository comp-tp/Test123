/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: ProviderModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2009-2011
 * 
 *  Description:
 *  ProviderModel4WS model..
 *  
 *  Notes:
 * $Id: ProviderModel4WS.cs 206999 2011-11-09 01:21:42Z ACHIEVO\alan.hu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    
    [DataContract]
    
    
    
    public partial class ProviderModel4WS : ProviderPKModel4WS
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string externalExamURL { get; set; }

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
        public RefContinuingEducationModel4WS[] refContEducations { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public RefEducationModel4WS[] refEduModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public RefExaminationModel4WS[] refExaminations { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public RefLicenseProfessionalModel4WS refLicenseProfessionalModel { get; set; }
    }
}
