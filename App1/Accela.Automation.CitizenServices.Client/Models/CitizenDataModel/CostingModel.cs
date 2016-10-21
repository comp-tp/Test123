#region Header
/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: CostingModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: CostingModel.cs 181867 2010-10-06 08:06:18Z ACHIEVO\daly.zeng $.
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
    
    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://service.webservice.accela.com/")]
    public partial class CostingModel : LanguageModel
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
        [DataMember(EmitDefaultValue=false)]
        public CapIDModel capID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string costCategory { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string costStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double costTotal { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool costTotalSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string costingComments { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string costingCostAccount { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.DateTime costingCostDate { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool costingCostDateSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.DateTime costingCostDateTo { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool costingCostDateToSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double costingCostFactor { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool costingCostFactorSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double costingCostFix { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool costingCostFixSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long costingCostID { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool costingCostIDSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string costingCostItem { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string costingCostType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string costingCostTypeItem { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CostingPK costingPK { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double costingQuantity { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool costingQuantitySpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double costingTotalCost { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool costingTotalCostSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double costingUnitCost { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool costingUnitCostSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string costingUnitOfMeasure { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string distributeFlag { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string endTime { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long relatedAsgnNbr { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool relatedAsgnNbrSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string startTime { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string workOrderTaskCode { get; set; }
    }
}
