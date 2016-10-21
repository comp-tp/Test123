/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: GValuationModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: GValuationModel4WS.cs 
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 *//// <remarks/>
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    [DataContract]
    public partial class GValuationModel4WS
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long calcValueSeqNbr { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string conTyp { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string effectDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string effectEndDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string effectStartDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string excludeRegionalModifier { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string expireDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string expireEndDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string expireStartDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string feeIndicator { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long groupID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string groupName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string servProvCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double totalValue { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double unitAmount { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string unitTyp { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double unitValue { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string useTyp { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string version { get; set; }
    }
}