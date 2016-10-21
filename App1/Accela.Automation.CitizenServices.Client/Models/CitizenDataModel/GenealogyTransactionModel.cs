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
 * $Id: GenealogyTransactionModel.cs 185933 2010-12-07 03:41:40Z ACHIEVO\daly.zeng $.
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
    
    
    
    public partial class GenealogyTransactionModel
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public GenealogyModel[] childGenealogyModels { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string genTranAction { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> genTranDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string genTranDesc { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long genTranID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public ParcelModel[] parcelModels { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public GenealogyModel[] parentGenealogyModels { get; set; }
    }
}
