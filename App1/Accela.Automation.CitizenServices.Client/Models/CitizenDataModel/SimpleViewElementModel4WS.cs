/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: SimpleViewElementModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2007-2012
 * 
 *  Description:
 *  SimpleViewElementModel4WS model..
 *  
 *  Notes:
 * $Id: SimpleViewElementModel4WS.cs 211752 2012-01-10 08:38:41Z ACHIEVO\alan.hu $.
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
    
    
    
    public partial class SimpleViewElementModel4WS
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string displayOrder { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int elementHeight { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string elementInstruction { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int elementLeft { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int elementTop { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string elementType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int elementWidth { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int inputWidth { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool isOriginalTemplate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string labelId { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string labelValue { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int labelWidth { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string readOnly { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string recStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string required { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string sectionID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public TemplateAttrValueModel[] selectOptions { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string servProvCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string sortOrder { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string standard { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string unitType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int unitWidth { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string viewElementDesc { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string viewElementId { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string viewElementName { get; set; }
    }
}
