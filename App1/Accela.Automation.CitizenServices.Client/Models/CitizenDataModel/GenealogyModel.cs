/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: ACAModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: GenealogyModel.cs 185933 2010-12-07 03:41:40Z ACHIEVO\daly.zeng $.
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
    
    
    
    public partial class GenealogyModel
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long genSeqNbr { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string genSource { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long genStageNbr { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long genTranID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string gisID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string objectNbr { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string objectType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> recDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string recFullName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string recStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string unmaskedObjectNbr { get; set; }
    }
}
