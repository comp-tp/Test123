/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: CapPaymentResultModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: CapPaymentResultModel.cs 181105 2010-09-15 11:26:45Z ACHIEVO\hans.shi $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    
    [DataContract]
    
    
    
    public partial class CapPaymentResultModel
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string actionSource { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CapIDModel capID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool hasFee { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string moduleName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string paramString { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool paymentStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string receiptNbr { get; set; }
    }
}
