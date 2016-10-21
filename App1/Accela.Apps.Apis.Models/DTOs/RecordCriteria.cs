using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DTOs
{
    [DataContract]
    public class RecordCriteria
    {
        /// <summary>
        /// Return element type.
        /// </summary>
        public enum ReturnElementType
        {
            Basic,
            All,
            Minimum,
            CAPIDs
        }

        public enum SearchType4Citizen
        {
            Unknown,
            GenericSearch,
            SearchByAddress,
            SearchByContact,
            SearchByIds
        }

        public SearchType4Citizen CivicSearchType { get; set; }

        /// <summary>
        /// this is record display
        /// if we have record ids, then the field will be ignore
        /// </summary>
        [DataMember(Name = "display", EmitDefaultValue = false)]
        public string Display { get; set; }

        /// <summary>
        /// Display collection.
        /// </summary>
        [DataMember(Name = "displays", EmitDefaultValue = false)]
        public List<string> Displays { get; set; }

        /// <summary>
        /// Scheduled Date From.
        /// </summary>
        [DataMember(Name = "openedDateFrom", EmitDefaultValue = false)]
        public string OpenedDateFrom { get; set; }

        /// <summary>
        /// Scheduled Date To
        /// </summary>
        [DataMember(Name = "openedDateTo", EmitDefaultValue = false)]
        public string OpenedDateTo { get; set; }

        /// <summary>
        /// Search by Record Ids
        /// </summary>
        [DataMember(Name = "recordIds", EmitDefaultValue = false)]
        public List<string> RecordIds { get; set; }

        /// <summary>
        /// Search by Record Type Ids
        /// </summary>
        [DataMember(Name = "recordTypeIds", EmitDefaultValue = false)]
        public List<string> RecordTypeIds { get; set; }

        /// <summary>
        /// Search By Record Status Ids
        /// </summary>
        [DataMember(Name = "recordStatusIds", EmitDefaultValue = false)]
        public List<string> RecordStatusIds { get; set; }

        /// <summary>
        /// Search by record aliases
        /// </summary>
        [DataMember(Name = "aliases", EmitDefaultValue = false)]
        public List<string> Aliases { get; set; }

        /// <summary>
        /// Search by staff Ids.
        /// </summary>
        [DataMember(Name = "staffIds", EmitDefaultValue = false)]
        public List<string> StaffIds { get; set; }

        /// <summary>
        /// Search By Inspection District Ids
        /// </summary>
        [DataMember(Name = "inspectionDistrictIds", EmitDefaultValue = false)]
        public List<string> InspectionDistrictIds { get; set; }

        /// <summary>
        /// Search By Inspection Schedule From.
        /// If the field is null,empty or non-integer type. System will ignore the search condition
        /// Example: If the field is 2. the mean records that match Inspection schedule date above today-2.
        /// </summary>
        [DataMember(Name = "inspectionScheduledDateFrom", EmitDefaultValue = false)]
        public string InspectionScheduledDateFrom { get; set; }

        /// <summary>
        /// Search By Inspection Schedule From.
        /// If the field is null,empty or non-integer type. System will ignore the search condition
        /// Example: If the field is 2. the mean records that match Inspection schedule date less today+2.
        /// </summary>
        [DataMember(Name = "inspectionScheduledDateTo", EmitDefaultValue = false)]
        public string InspectionScheduledDateTo { get; set; }

        /// <summary>
        /// Search By Record Schedule Date.
        /// If the field is null,empty or non-integer type. System will ignore the search condition
        /// Example: If the field is 2. the mean records that match record schedule date above today-2.
        /// </summary>
        [DataMember(Name = "recordScheduledDateFrom", EmitDefaultValue = false)]
        public string RecordScheduledDateFrom { get; set; }

        /// <summary>
        /// Search By Record Schedule Date.
        /// If the field is null,empty or non-integer type. System will ignore the search condition
        /// Example: If the field is 2. the mean records that match record schedule date less today+2.
        /// </summary>
        [DataMember(Name = "recordScheduledDateTo", EmitDefaultValue = false)]
        public string RecordScheduledDateTo { get; set; }

        /// <summary>
        /// Search by Inspection Type Ids
        /// </summary>
        [DataMember(Name = "inspectionTypeIds", EmitDefaultValue = false)]
        public List<string> InspectionTypeIds { get; set; }

        /// <summary>
        /// Search by Inspector Ids
        /// </summary>
        [DataMember(Name = "inspectorIds", EmitDefaultValue = false)]
        public List<string> InspectorIds { get; set; }

        /// <summary>
        /// Search by keyword
        /// </summary>
        [DataMember(Name = "keyword", EmitDefaultValue = false)]
        public string Keyword { get; set; }

        /// <summary>
        /// Search by Parent Record Id
        /// </summary>
        [DataMember(Name = "parentRecordId", EmitDefaultValue = false)]
        public string ParentRecordId { get; set; }

        /// <summary>
        /// Search by Partial Record Id
        /// </summary>
        [DataMember(Name = "partialRecordId", EmitDefaultValue = false)]
        public string PartialRecordId { get; set; }

        /// <summary>
        /// Search by Subsidiary Record Id
        /// </summary>
        [DataMember(Name = "subsidiaryRecordId", EmitDefaultValue = false)]
        public string SubsidiaryRecordId { get; set; }

        /// <summary>
        /// The type is mean "Permit" or other else
        /// </summary>
        [DataMember(Name = "moduleType", EmitDefaultValue = false)]
        public string moduleType { get; set; }

        /// <summary>
        /// Search will been in cached record
        /// </summary>
        [DataMember(Name = "useCachedRecords", EmitDefaultValue = false)]
        public string UseCachedRecords { get; set; }

        /// <summary>
        /// Only search with opened inspections
        /// </summary>
        [DataMember(Name = "withOpenInspectionsOnly", EmitDefaultValue = false)]
        public string WithOpenInspectionsOnly { get; set; }

        /// <summary>
        /// Search by Asset Ids
        /// </summary>
        [DataMember(Name = "assetIds", EmitDefaultValue = false)]
        public List<string> AssetIds { get; set; }

        /// <summary>
        /// How much records will been return in one asset if asset element will be returned
        /// </summary>
        [DataMember(Name = "maxRecordsPerAssetId", EmitDefaultValue = false)]
        public string MaxRecordsPerAssetId { get; set; }

        public string ParcelNumber { get; set; }

        /// <summary>
        /// Address.
        /// </summary>
        [DataMember(Name = "address", EmitDefaultValue = false)]
        public AddressFilter Address { get; set; }

        /// <summary>
        /// Contact.
        /// </summary>
        [DataMember(Name = "contact", EmitDefaultValue = false)]
        public ContactFilter Contact { get; set; }

        /// <summary>
        /// Return elements.
        /// </summary>
        [DataMember(Name = "returnElements", EmitDefaultValue = false)]
        public List<string> ReturnElements { get; set; }

        [DataMember(Name = "module", EmitDefaultValue = false)]
        public string Module { get; set; }

        [DataMember(Name = "bBox", EmitDefaultValue = false)]
        public BBox BBoxValue { get; set; }

        [DataMember(Name = "geoCircle", EmitDefaultValue = false)]
        public GeoCircle GeoCircle { get; set; }
    }

    [DataContract(Name = "address")]
    public class AddressFilter
    {
        [DataMember(Name = "houseNumber")]
        public string HouseNumber { get; set; }

        [DataMember(Name = "streetName")]
        public string StreetName { get; set; }

        [DataMember(Name = "streetDirection")]
        public string StreetDirection { get; set; }        

        [DataMember(Name = "city")]
        public string City { get; set; }

        [DataMember(Name = "state")]
        public string State { get; set; }

        [DataMember(Name = "zipCode")]
        public string ZipCode { get; set; }

    }

    [DataContract(Name = "contact")]
    public class ContactFilter
    {
        [DataMember(Name = "name")]
        public string PersonName { get; set; }

        [DataMember(Name = "firstName")]
        public string FirstName{ get; set;}

        [DataMember(Name = "middleName")]
        public string MiddleName { get; set; }

        [DataMember(Name = "lastName")]
        public string LastName { get; set; }
    
    }
}
