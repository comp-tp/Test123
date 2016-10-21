#region Header
/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: AssetMasterModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: AssetMasterModel.cs 181867 2010-10-06 08:06:18Z ACHIEVO\daly.zeng $.
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
    public partial class AssetMasterModel : LanguageModel
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public AssetOrderModel assetOrderModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public AssetRatingModel[] assetRatingList { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double assetSize { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool assetSizeSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string capTypeString { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public decimal cost { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool costSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public decimal costLTD { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool costLTDSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double currentValue { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool currentValueSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.DateTime dateOfService { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool dateOfServiceSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string dependentFlag { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double depreciationAmount { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool depreciationAmountSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double depreciationValue { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool depreciationValueSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string endAssetID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double endAssetSize { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool endAssetSizeSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double endCurrentValue { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool endCurrentValueSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.DateTime endDate { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool endDateSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.DateTime endDateOfService { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool endDateOfServiceSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.DateTime endEndDate { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool endEndDateSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.DateTime endStartDate { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool endStartDateSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.DateTime endStatusDate { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool endStatusDateSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string g1AssetComments { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string g1AssetGroup { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string g1AssetID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string g1AssetName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long g1AssetSequenceNumber { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool g1AssetSequenceNumberSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string g1AssetStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.DateTime g1AssetStatusDate { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool g1AssetStatusDateSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string g1AssetType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string g1ClassType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string g1Description { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string parentAsset { get; set; }

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
        public RefAddressModel[] refAddressList { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public RefAddressModel refAddressModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public AssetContactModel[] refContactsList { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resG1AssetComments { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resG1AssetName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resG1Description { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double salvageValue { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool salvageValueSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string serviceProviderCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string sizeUnit { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string startAssetID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.DateTime startDate { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool startDateSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double startValue { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool startValueSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long totalNum { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool totalNumSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double useFulLife { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool useFulLifeSpecified { get; set; }
    }    
}
