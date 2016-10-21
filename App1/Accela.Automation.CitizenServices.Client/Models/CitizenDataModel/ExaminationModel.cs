#region Header
/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: ExaminationModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010-2011
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3053")]
    [DataContract]
    
    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://service.webservice.accela.com/")]
    public partial class ExaminationModel
    {

        /// <summary>
        /// Row Index
        /// </summary>
        public int RowIndex
        {
            get;
            set;
        }

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

        ///// <remarks/>
        //[DataMember(EmitDefaultValue=false)]
        //public System.Nullable<System.DateTime> endTime { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long examAttempt { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool examAttemptSpecified { get; set; }

        ///// <remarks/>
        //[DataMember(EmitDefaultValue=false)]
        //public System.Nullable<System.DateTime> examDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string examName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public ExamProviderDetailModel examProviderDetailModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string examStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public ExaminationPKModel examinationPKModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string externalUserID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<double> finalScore { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string gradingStyle { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> locationID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<double> passingScore { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string providerName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string providerNo { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> refExamSeq { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string requiredFlag { get; set; }

        ///// <remarks/>
        //[DataMember(EmitDefaultValue=false)]
        //public System.Nullable<System.DateTime> startTime { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string userExamID { get; set; }
    }
}
