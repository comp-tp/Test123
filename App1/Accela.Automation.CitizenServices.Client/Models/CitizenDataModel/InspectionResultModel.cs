/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: InspectionResultModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010-2012
 * 
 *  Description:
 * 
 *  Notes:
 * 
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3053")]
    [DataContract]
    
    
    
    public partial class InspectionResultModel
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> auditDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditId { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<int> order { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resultImage { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resultType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resultValue { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resultCategory { get; set; }
    }
}

