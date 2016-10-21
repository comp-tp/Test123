/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: RefAddressModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010-2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: RefAddressModel.cs 130107 2009-05-11 12:23:56Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    
    [DataContract]
    
    
    
    public partial class RefAddressModel
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string addressDescription { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string addressLine1 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string addressLine2 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string addressStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string addressType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string addressTypeFlag { get; set; }

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
        public System.Nullable<double> distance { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public DuplicatedAPOKeyModel[] duplicatedAPOKeys { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string eventID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string fullAddress { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public NoticeConditionModel hightestCondition { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string houseFractionEnd { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string houseFractionStart { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<int> houseNumberEnd { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<int> houseNumberRangeEnd { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<int> houseNumberRangeStart { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<int> houseNumberStart { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string inspectionDistrict { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string inspectionDistrictPrefix { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string lot { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string mappingDailyAddressNbr { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string neighberhoodPrefix { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string neighborhood { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public NoticeConditionModel[] noticeConditions { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public ParcelInfoModel[] parcelLists { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string parcelNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string primaryFlag { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> refAddressId { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string[] refAddressTypes { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resCountryCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resState { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resStreetDirection { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resStreetSuffix { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resStreetSuffixdirection { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resUnitType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string secondaryRoad { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<int> secondaryRoadNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string sourceFlag { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<int> sourceNumber { get; set; }

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
        public string subdivision { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public TemplateAttributeModel[] templates { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string UID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string unitEnd { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string unitRangeEnd { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string unitRangeStart { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string unitStart { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string unitType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<double> XCoordinator { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<double> YCoordinator { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string zip { get; set; }
    }
    
}
