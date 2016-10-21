﻿#region Header
/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: GGSItemASIModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: GGSItemASIModel.cs 181867 2010-10-06 08:06:18Z ACHIEVO\daly.zeng $.
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
    
    
    
    public partial class GGSItemASIModel
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string alignment { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string asiName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string attributeUnitType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string attributeValue { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string attributeValueReqFlag { get; set; }

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
        public string checkBoxInd { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string checklistComment { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string defaultSelected { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool disabled { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int displayLength { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool displayLengthSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long displayOrder { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public RefAppSpecInfoDropDownModel[] dropDownValues { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int maxLength { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool maxLengthSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool supervisorEditOnly { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool supervisorEditOnlySpecified { get; set; }
    }
}