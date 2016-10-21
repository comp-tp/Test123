/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: BizDomainModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010-2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: BizDomainModel.cs 130107 2010-08-13 12:23:56Z ACHIEVO\alan.hu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [DataContract]
    
    
    
    public partial class BizDomainModel : LanguageModel
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> auditDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string bizdomain { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string bizdomainValue { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string description { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string dispBizdomainValue { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string dispDescription { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long dispositionID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> parentID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resBizdomainValue { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resDescription { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string serviceProviderCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int sortOrder { get; set; }
    }
}
