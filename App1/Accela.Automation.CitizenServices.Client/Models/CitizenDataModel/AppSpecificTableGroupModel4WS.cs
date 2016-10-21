/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: AppSpecificTableGroupModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2007-2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: AppSpecificTableGroupModel4WS.cs 179785 2010-08-25 12:14:08Z ACHIEVO\daly.zeng $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3053")]
    [DataContract]
    
    
    
    public partial class AppSpecificTableGroupModel4WS
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CapIDModel4WS capIDModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string groupName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string instruction { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resInstruction { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string[] tablesMap { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public AppSpecificTableModel4WS[] tablesMapValues { get; set; }
    }
}
