/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: ComponentModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010-2012
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: ComponentModel.cs 131140 2010-08-12 03:22:37Z ACHIEVO\daly.zeng $.
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
    
    
    
    public partial class ComponentModel : LanguageModel
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
        public long componentID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string componentName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long componentSeqNbr { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string customHeading { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string displayFlag { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int displayOrder { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string editableFlag { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string pageFlowGrpCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long pageID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string portletRange1 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string portletRange2 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string requiredFlag { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resCustomHeading { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string serviceProviderCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string validateFlag { get; set; }
    }
}
