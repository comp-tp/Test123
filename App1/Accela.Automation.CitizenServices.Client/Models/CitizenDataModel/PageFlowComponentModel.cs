/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: CommonPageFlowModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010-2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: CommonPageFlowModel.cs 171698 2010-12-02 09:39:39Z ACHIEVO\kale.huang $.
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
    
    
    
    public partial class PageFlowComponentModel : LanguageModel
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string afterClickEventName { get; set; }

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
        public string beforeClickEventName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long componentID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string componentName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int componentOrder { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long componentSeqNbr { get; set; }/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string customHeading { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string displayFlag { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string editableFlag { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string groupCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string instruction { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string onloadEventName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string pageFlowType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long pageID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string pageName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int pageOrder { get; set; }

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
        public string resPortletRange2 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string servProvCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long stepID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string stepName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int stepOrder { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string validateFlag { get; set; }
    }
}
