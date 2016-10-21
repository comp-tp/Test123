#region Header
/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: BCalcValuatnModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: BCalcValuatnModel.cs 181867 2010-10-06 08:06:18Z ACHIEVO\daly.zeng $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
#endregion Header
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3053")]
    [DataContract]
    
    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://service.webservice.accela.com/")]
    public partial class BCalcValuatnModel
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.DateTime auditDate { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool auditDateSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long calcValueSeqNbr { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CapIDModel capID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string conTyp { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string disConType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string disUnitType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string disUseType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string disVersion { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string excludeRegionalModifier { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string feeIndicator { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double totalValue { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double unitCost { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string unitTyp { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double unitValue { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string useTyp { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string version { get; set; }
    }
}
