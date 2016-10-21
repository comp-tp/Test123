#region Header
/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: StandardCommentModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: StandardCommentModel.cs 181867 2010-10-06 08:06:18Z ACHIEVO\daly.zeng $.
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
    public partial class StandardCommentModel : LanguageModel
    {
        /// <remarks/>
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
        public string comment { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string commonType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string dispCommonType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string documentID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string langID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string name { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string originalCommonType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string originalDocumentID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resComment { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resCommonType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resDocumentID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int res_id { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string serviceProviderCode { get; set; }
    }
}
