/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: CapWithConditionModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2007-2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: CapWithConditionModel4WS.cs 181867 2010-09-30 08:06:18Z ACHIEVO\daly.zeng $.
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
    
    
    
    public partial class CapWithConditionModel4WS
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CapModel4WS capModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public NoticeConditionModel conditionModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public NoticeConditionModel[] conditionModelArray { get; set; }
    }
}
