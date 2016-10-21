#region Header
/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: PaymentModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: PaymentModel.cs 182693 2010-10-19 08:24:27Z ACHIEVO\daly.zeng $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
#endregion Headerusing System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3053")]
    [DataContract]
    
    
    
    public partial class PaymentModel : PaymentBaseModel
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> batchTransCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string ccAuthCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string ccHolderName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string module { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> paymentMethodGroupNbr { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> posTransSeq { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double processingFee { get; set; }
    }
}
