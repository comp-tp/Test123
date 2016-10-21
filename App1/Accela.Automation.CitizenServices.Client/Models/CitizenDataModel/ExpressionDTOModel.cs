/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: ExpressionDTOModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: ExpressionDTOModel.cs 130107 2009-05-11 12:23:56Z ACHIEVO\jackie.yu $.
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
    
    
    
    public partial class ExpressionDTOModel
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string behavior { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public ExpressionFieldModel[] inputParams { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public ExpressionFieldModel[] runResult { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string viewKey1 { get; set; }
    }
}
