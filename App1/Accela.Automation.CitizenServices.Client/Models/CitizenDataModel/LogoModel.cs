/*
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: LogoModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: LogoModel.cs 186475 2010-12-13 09:51:23Z ACHIEVO\hans.shi $.
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
    
    
    
    public partial class LogoModel
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
        [DataMember(EmitDefaultValue = false)]
        public byte[] docContent { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string docDesc { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string docName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string logoType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string logoURL { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string serviceProviderCode { get; set; }
    }
}
