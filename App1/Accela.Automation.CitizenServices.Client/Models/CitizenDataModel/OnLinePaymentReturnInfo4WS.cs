/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: OnLinePaymentReturnInfo4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2007-2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: OnLinePaymentReturnInfo4WS.cs 182693 2010-10-19 08:24:27Z ACHIEVO\daly.zeng $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    
    [DataContract]
    
    
    
    public partial class OnLinePaymentReturnInfo4WS
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string accelaTransCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string agencyTransCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string batchNbr { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string errCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public PaymentModel payment { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public PayTrail[] paymentTrails { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string rtnMsg { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public TransactionModel4WS[] transactionLogs { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool updLicenseStatus { get; set; }
    }
}
