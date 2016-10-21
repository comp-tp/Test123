/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: ExpressionRunResultModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2009-2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: ExpressionRunResultModel4WS.cs 130107 2009-05-11 12:23:56Z ACHIEVO\jackie.yu $.
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [DataContract]
    
    
    
    public partial class ExpressionRunResultModel4WS
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long>[] exceptionsMapKeys { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string[] exceptionsMapValues { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public ExpressionFieldModel[] fields { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long>[] messagesMapKeys { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string[] messagesMapValues { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string[] newRowsMapKeys { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<int>[] newRowsMapValues { get; set; }
    }
}
