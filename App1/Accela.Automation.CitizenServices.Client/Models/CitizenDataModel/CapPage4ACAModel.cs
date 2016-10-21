/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: CapPage4ACAModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: CapPage4ACAModel.cs 171698 2010-04-29 09:39:39Z ACHIEVO\daly.zeng $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SimpleCapModel))]
    
    [DataContract]
    
    
    
    public partial class CapPage4ACAModel : LanguageModel
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string accessByACA { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string createdBy { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string createdByACA { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> expDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool hasPrivilegeToHandleCap { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool hasPrivilegeToReadCap { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool isTNExpired { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool noPaidFeeFlag { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string renewalStatus { get; set; }
    }

}
