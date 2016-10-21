/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: PublicUserPlanModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2007-2009
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: PublicUserPlanModel4WS.cs 130107 2009-05-11 12:23:56Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [DataContract]
    public partial class PublicUserPlanModel4WS
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string checkDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string fileDisplayName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string filePath { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string planName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long planSeqNbr { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string planStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string publicUserID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string recDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string recFulName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string recStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public byte[] reportDocument { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int retryTimes { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string[] ruleSet { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string servProvCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string submitDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string transactionID { get; set; }
    }
}
