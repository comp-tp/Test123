/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: EdmsUserModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: EdmsUserModel4WS.cs 130107 2009-05-11 12:23:56Z ACHIEVO\jackie.yu $.
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
    
    
    
    public partial class EdmsUserModel
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string authID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string authType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string edmsName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string edmsPassword { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string edmsUserName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long policySeq { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool policySeqSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> recDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string recFulName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string recStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string serviceProviderCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string updatePwdFlag { get; set; }
    }
}
