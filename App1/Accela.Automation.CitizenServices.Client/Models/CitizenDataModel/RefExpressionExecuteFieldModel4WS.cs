/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: RefExpressionExecuteFieldModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2007-2009
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: RefExpressionExecuteFieldModel4WS.cs 130107 2009-05-11 12:23:56Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.42")]
    [DataContract]
    
    
    
    public partial class RefExpressionExecuteFieldModel4WS
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string m_executeField { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string m_expressionName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string m_fireEvent { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string m_servProvCode { get; set; }
    }
}
