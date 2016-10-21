/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: AddressBaseModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: AddressBaseModel.cs 171698 2010-04-29 09:39:39Z ACHIEVO\daly.zeng $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AddressModel))]
    
    [DataContract]
    
    
    
    public partial class AddressBaseModel
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string addressDescription { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string addressStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string addressTypeFlag { get; set; }

        ///// <remarks/>
        //[DataMember(EmitDefaultValue=false)]
        //public System.Nullable<System.DateTime> auditDate { get; set; }

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
        public string city { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string country { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string countryCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string county { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string eventID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string fullAddress { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string houseFractionEnd { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string houseFractionStart { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string inspectionDistrict { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string inspectionDistrictPrefix { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string neighberhoodPrefix { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string neighborhood { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string primaryFlag { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string secondaryRoad { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string serviceProviderCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string sourceFlag { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string state { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string streetDirection { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string streetName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string streetPrefix { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string streetSuffix { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string streetSuffixdirection { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string UID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string unitEnd { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string unitStart { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string unitType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string zip { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resState
        {
            get;
            set;
        }
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resCountryCode
        {
            get;
            set;
        }
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resStreetDirection
        {
            get;
            set;
        }
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resStreetSuffixdirection
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resUnitType
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resStreetSuffix
        {
            get;
            set;
        }
    }
}
