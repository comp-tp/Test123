/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: EntityPaymentResultModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: EntityPaymentResultModel.cs 181105 2010-09-15 11:26:45Z ACHIEVO\hans.shi $.
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
    
    
    
    public partial class EntityPaymentResultModel
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string entityID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string entityType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string errorCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string paramString { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long receiptNbr { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double paidAmount { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string actionSource { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool isSuccess { get; set; }        
    }
}
