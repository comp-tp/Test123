#region Header
/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: PartTransactionModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: PartTransactionModel.cs 181867 2010-10-06 08:06:18Z ACHIEVO\daly.zeng $.
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
    public partial class PartTransactionModel : LanguageModel
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string altID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string capID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string comments { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double costTotal { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool costTotalSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string distributeFlag { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string hardReservation { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string ID1 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string ID2 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string ID3 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public object[] locSupplyCol { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long locationSeq { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool locationSeqSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string partBin { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string partBrand { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string partDescription { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string partLocation { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string partNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long partSeq { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool partSeqSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string partType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double quantity { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool quantitySpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.DateTime recDate { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool recDateSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string recFulNam { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string recStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resPartBrand { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resPartDescription { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resPartLocation { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resToPartLocation { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resWorkOrderTaskCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long reservationNum { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool reservationNumSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string reservationStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string servProvCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string taxable { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long toLocationSeq { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool toLocationSeqSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string toPartLocation { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double transactionCost { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool transactionCostSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.DateTime transactionDate { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool transactionDateSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.DateTime transactionDateFrom { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool transactionDateFromSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.DateTime transactionDateTo { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool transactionDateToSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long transactionSeq { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool transactionSeqSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string transactionType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double unitCost { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool unitCostSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string unitOfMeasurement { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string workOrderTaskCode { get; set; }
    }
}
