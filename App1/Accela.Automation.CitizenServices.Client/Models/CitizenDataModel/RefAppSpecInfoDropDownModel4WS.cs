/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: RefAppSpecInfoDropDownModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2007-2009
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: RefAppSpecInfoDropDownModel4WS.cs 130107 2009-05-11 12:23:56Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    
    [DataContract]
    
    
    
    public partial class RefAppSpecInfoDropDownModel4WS
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string attrValue { get; set; }

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
        public string checkboxGroup { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string fieldLabel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string groupCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string groupName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resAttrValue { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string serviceProviderCode { get; set; }
    }
}
