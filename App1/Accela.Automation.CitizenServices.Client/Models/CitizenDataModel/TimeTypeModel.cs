#region Header
/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: TimeTypeModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: TimeTypeModel.cs 181867 2010-10-06 08:06:18Z ACHIEVO\daly.zeng $.
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
    public partial class TimeTypeModel : LanguageModel
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string billableFlag { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CapTypeModel capTypeModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double defaultPctAdj { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool defaultPctAdjSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double defaultRate { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool defaultRateSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.DateTime recDate { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool recDateSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string recFulName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string recStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string recordType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resTimeTypeName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string servProvCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public TimeGroupModel[] timeGroups { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string timeTypeDesc { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string timeTypeName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long timeTypeSeq { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool timeTypeSeqSpecified { get; set; }
    }
}
