/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: RefExaminationModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2009
 * 
 *  Description:
 *  RefExaminationModel4WS model..
 * 
 *  Notes:
 * $Id: RefExaminationModel4WS.cs 137738 2009-07-06 06:52:41Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [DataContract]
    public partial class RefExaminationModel4WS : RefExaminationPKModel4WS 
    {
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public AuditModel4WS auditModel 
        {
            get;
            set;
        }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string comments 
        {
            get;
            set;
        }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string examName 
        {
            get;
            set;
        }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string gradingStyle 
        {
            get;
            set;
        }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string passingPercentage 
        {
            get;
            set;
        }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string passingScore 
        {
            get;
            set;
        }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public ProviderModel4WS[] providerModels 
        {
            get;
            set;
        }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public XRefExaminationAppTypeModel4WS[] refExamAppTypeModels 
        {
            get;
            set;
        }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public XRefExaminationProviderModel4WS[] refExamProviderModels 
        {
            get;
            set;
        }
    }
}
