/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: InfoTableColumnModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: InfoTableColumnModel4WS.cs 130107 2009-05-11 12:23:56Z 
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    
    [DataContract]
    
    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://webservice.onlinePayment.cashier.finance.aa.accela.com")]
    public partial class InfoTableColumnModel4WS
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditId { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string defaultValue { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string dispDefaultValue { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string dispName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string displayLength { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string displayOrder { get; set; }

        ///<remarks/>
        [DataMember(EmitDefaultValue=false)]
        public LabelValueBean[] dropDownValues { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string feeIndicator { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string fieldType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string id { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string maxLength { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string name { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string requiredFlag { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resDefaultValue { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string searchableFlag { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public InfoTableValueModel4WS[] tableValues { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string unitType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string displayLicVeriForACA { get; set; }
    }
}
