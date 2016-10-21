#region Header
/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: expressionRuntimeArgumentPKModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: expressionRuntimeArgumentPKModel.cs 181867 2011-01-03 08:06:18Z ACHIEVO\kale.huang $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
#endregion Header
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [DataContract]
    
    
    
    public partial class ExpressionRuntimeArgumentPKModel
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> portletID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string viewKey1 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string viewKey2 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string viewKey3 { get; set; }
    }
}