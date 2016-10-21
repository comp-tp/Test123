/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: OnlinePaymentResultModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: OnlinePaymentResultModel.cs 181105 2010-09-15 11:26:45Z ACHIEVO\hans.shi $.
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
    
    
    
    public partial class OnlinePaymentResultModel
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string batchNbr { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CapPaymentResultModel[] capPaymentResultModels { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public EntityPaymentResultModel[] entityPaymentResultModels { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string[] exceptionMsg { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string paramString { get; set; }
    }
}
