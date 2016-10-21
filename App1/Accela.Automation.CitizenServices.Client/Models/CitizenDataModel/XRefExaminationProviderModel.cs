#region Header
/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: XRefExaminationProviderModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2012
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: XRefExaminationProviderModel.cs 181867 2011-09-27 08:06:18Z ACHIEVO\daly.zeng $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
#endregion Header
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [DataContract]
    public partial class XRefExaminationProviderModel : RefExaminationProviderPKModel {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public SimpleAuditModel auditModel { get; set; }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string comments { get; set; }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string externalExamId { get; set; }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string externalExamName { get; set; }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string gradingStyle { get; set; }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string isAllowDelete { get; set; }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string isSchedulingInACA { get; set; }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string passingPercentage { get; set; }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<double> passingScore { get; set; }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string passingScore2String { get; set; }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public ProviderModel providerModel { get; set; }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<double> reScheduleDeadline { get; set; }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public RefExaminationModel refExaminationModel { get; set; }    
    }
}