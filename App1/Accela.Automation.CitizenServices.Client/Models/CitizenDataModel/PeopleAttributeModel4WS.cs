/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: PeopleAttributeModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2007-2009
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: PeopleAttributeModel4WS.cs 130107 2009-05-11 12:23:56Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.42")]
    [DataContract]
    
    
    
    public partial class PeopleAttributeModel4WS
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string attributeLabel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string attributeName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string attributeUnitType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string attributeValue { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string attributeValueDataType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string attributeValueReqFlag { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string contactNo { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string contactType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long displayOrder { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string serviceProviderCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string validationScript { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string vchFlag { get; set; }
    }
}
