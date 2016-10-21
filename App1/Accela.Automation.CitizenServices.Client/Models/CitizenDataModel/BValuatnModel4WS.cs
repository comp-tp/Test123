/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: BValuatnModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2007-2009
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: BValuatnModel4WS.cs 130107 2009-05-11 12:23:56Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    
    [DataContract]
    
    
    
    public partial class BValuatnModel4WS
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
        public double calculatedValue { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CapIDModel4WS capID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string estimatedValue { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string feeFactorFlag { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double planCheckValue { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string valuationPeriod { get; set; }
    }
}
