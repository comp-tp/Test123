/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: B1ExpirationModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2007-2009
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: B1ExpirationModel4WS.cs 130107 2009-05-11 12:23:56Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    
    [DataContract]
    
    
    
    public partial class B1ExpirationModel4WS
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
        public CapIDModel4WS capIDModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string expCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string expDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string expDateString { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long expInterval { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string expStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string expUnit { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long graceInterval { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string graceUnit { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string payPeriodGroup { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string penaltyCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string penaltyFunction { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long penaltyInterval { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long penaltyNum { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long penaltyPeriod { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string penaltyUnit { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string renewalCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string renewalFunction { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string udf1 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string udf2 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string udf3 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string udf4 { get; set; }
    }
    
}
