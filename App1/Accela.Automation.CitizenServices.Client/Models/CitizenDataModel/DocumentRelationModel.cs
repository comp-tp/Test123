#region Header
/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: DocumentRelationModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010-2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: DocumentRelationModel.cs 181867 2010-10-06 08:06:18Z ACHIEVO\daly.zeng $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
#endregion Header
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.225")]
    [DataContract]
    
    
    
    public partial class DocumentRelationModel
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string description { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string displayImage { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long documentNo { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool documentNoSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string entityID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string entityType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string fileKey { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.DateTime recDate { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool recDateSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string recFulNam { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string recStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long relationNbr { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool relationNbrSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string serviceProviderCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string source { get; set; }
    }
}
