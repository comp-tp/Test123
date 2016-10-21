using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs;

namespace Accela.Apps.Apis.WSModels.Records
{
    [DataContract(Name = "filter")]
    public class WSRecordFilter
    {
        [DataMember(Name = "ids", EmitDefaultValue = false)]
        public List<string> RecordIds { get; set; }

        [DataMember(Name = "types", EmitDefaultValue = false)]
        public List<string> RecordTypeIds { get; set; }

        [DataMember(Name = "statuses", EmitDefaultValue = false)]
        public List<string> RecordStatusIds { get; set; }

        //[DataMember(Name = "parcelIds", EmitDefaultValue = false)]
        //public List<string> PacelIds { get; set; }

        [DataMember(Name = "parcelNumber", EmitDefaultValue = false)]
        public string ParcelNumber { get; set; }

        [DataMember(Name = "aliases", EmitDefaultValue = false)]
        public List<string> Aliases { get; set; }

        [DataMember(Name = "staffIds", EmitDefaultValue = false)]
        public List<string> StaffIds { get; set; }

        [DataMember(Name = "streetName", EmitDefaultValue = false)]
        public string StreetName { get; set; }

        [DataMember(Name = "streetDirection", EmitDefaultValue = false)]
        public string StreetDirection { get; set; }        

        [DataMember(Name = "houseNumber", EmitDefaultValue = false)]
        public string HouseNumber { get; set; }

        [DataMember(Name = "city", EmitDefaultValue = false)]
        public string City { get; set; }

        [DataMember(Name = "state", EmitDefaultValue = false)]
        public string State { get; set; }

        [DataMember(Name = "zipCode", EmitDefaultValue = false)]
        public string ZipCode { get; set; }

        [DataMember(Name = "firstName", EmitDefaultValue = false)]
        public string FirstName { get; set; }

        [DataMember(Name = "middleName", EmitDefaultValue = false)]
        public string MiddleName { get; set; }

        [DataMember(Name = "lastName", EmitDefaultValue = false)]
        public string LastName { get; set; }

        [DataMember(Name = "openedDateFrom", EmitDefaultValue = false)]
        public string OpenedDateFrom { get; set; }

        [DataMember(Name = "openedDateTo", EmitDefaultValue = false)]
        public string OpenedDateTo { get; set; }

        [DataMember(Name = "scheduledDateFrom", EmitDefaultValue = false)]
        public string RecordScheduledDateFrom { get; set; }

        [DataMember(Name = "scheduledDateTo", EmitDefaultValue = false)]
        public string RecordScheduledDateTo { get; set; }

        [DataMember(Name = "module", EmitDefaultValue = false)]
        public string Module { get; set; }

        [DataMember(Name = "bBox", EmitDefaultValue = false)]
        public WSBBox BBoxValue { get; set; }

        [DataMember(Name = "geoCircle", EmitDefaultValue = false)]
        public WSGeoCircle GeoCircle { get; set; }

        public RecordCriteria.SearchType4Citizen GetSearchType4Citizen()
        {
            var result = RecordCriteria.SearchType4Citizen.Unknown;
            int containAddressCondition = 0;
            int containContactCondition = 0;
            int containIdsCondition = 0;
            int containOtherConditions = 0;

            if (!String.IsNullOrWhiteSpace(this.OpenedDateFrom)
                || !String.IsNullOrWhiteSpace(this.OpenedDateTo)
                || !String.IsNullOrWhiteSpace(this.RecordScheduledDateFrom)
                || !String.IsNullOrWhiteSpace(this.RecordScheduledDateTo)
                || !String.IsNullOrWhiteSpace(this.ParcelNumber)
                || (this.RecordTypeIds != null && this.RecordTypeIds.Count > 0)
                || (this.RecordStatusIds != null && this.RecordStatusIds.Count > 0)
                || (this.Aliases != null && this.Aliases.Count > 0)
                || (this.StaffIds != null && this.StaffIds.Count > 0)
                )
            {
                containOtherConditions = 1;
            }

            if (!(string.IsNullOrWhiteSpace(this.HouseNumber)
                && string.IsNullOrWhiteSpace(this.StreetName)
                && string.IsNullOrWhiteSpace(this.City)
                && string.IsNullOrWhiteSpace(this.State)
                && string.IsNullOrWhiteSpace(this.ZipCode)))
            {
                containAddressCondition = 1;
            }

            if (!(string.IsNullOrWhiteSpace(this.FirstName)
                && string.IsNullOrWhiteSpace(this.MiddleName)
                && string.IsNullOrWhiteSpace(this.LastName)))
            {
                containContactCondition = 1;
            }

            if ((this.RecordIds != null && this.RecordIds.Count > 0)
                || (this.BBoxValue != null && !String.IsNullOrWhiteSpace(this.BBoxValue.XMax))
                || (this.GeoCircle != null && !String.IsNullOrWhiteSpace(this.GeoCircle.CenterX))
                )
            {
                containIdsCondition = 1;
            }

            var totalConditions = containAddressCondition + containContactCondition + containIdsCondition + containOtherConditions;

            if (containIdsCondition == 1)
            {
                result = RecordCriteria.SearchType4Citizen.SearchByIds;
            }
            else if (totalConditions > 1 || containOtherConditions == 1)
            {
                result = RecordCriteria.SearchType4Citizen.GenericSearch;
            }
            else if (containAddressCondition == 1)
            {
                result = RecordCriteria.SearchType4Citizen.SearchByAddress;
            }
            else if (containContactCondition == 1)
            {
                result = RecordCriteria.SearchType4Citizen.SearchByContact;
            }
            else
            {
                result = RecordCriteria.SearchType4Citizen.GenericSearch;
            }
            
            return result;
        }
    }
}
