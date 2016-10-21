using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ContactModels;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;
using Accela.Apps.Apis.Models.DTOs;

namespace Accela.Apps.Apis.WSModels.Inspections
{
    [DataContract(Name = "inspectionFilter")]
    public class WSInspectionFilter
    {
        [DataMember(Name = "contactFamilyName", EmitDefaultValue = false)]
        public string ContactFamilyName { get; set; }

        [DataMember(Name = "contactGivenName", EmitDefaultValue = false)]
        public string ContactGivenName { get; set; }

        [DataMember(Name = "contactMiddleNames", EmitDefaultValue = false)]
        public List<string> ContactMiddleNames { get; set; }

        [DataMember(Name = "startDate", EmitDefaultValue = false)]
        public string StartDate { get; set; }

        [DataMember(Name = "endDate", EmitDefaultValue = false)]
        public string EndDate { get; set; }

        [DataMember(Name = "types")]
        public List<string> Types { get; set; }

        [DataMember(Name = "parcelId")]
        public string ParcelId { get; set; }

        [DataMember(Name = "inspectorIds")]
        public List<string> InspectorIds { get; set; }

        [DataMember(Name = "houseNumber", EmitDefaultValue = false)]
        public string HouseNumber { get; set; }

        [DataMember(Name = "houseNumberFraction", EmitDefaultValue = false)]
        public string HouseNumberFraction { get; set; }

        [DataMember(Name = "streetDirection", EmitDefaultValue = false)]
        public string StreetDirection { get; set; }

        [DataMember(Name = "streetName", EmitDefaultValue = false)]
        public string StreetName { get; set; }

        [DataMember(Name = "streetSuffix", EmitDefaultValue = false)]
        public string StreetSuffix { get; set; }

        [DataMember(Name = "streetSuffixDirection", EmitDefaultValue = false)]
        public string StreetSuffixDirection { get; set; }

        [DataMember(Name = "unitStart", EmitDefaultValue = false)]
        public string UnitStart { get; set; }

        [DataMember(Name = "unitEnd", EmitDefaultValue = false)]
        public string UnitEnd { get; set; }

        [DataMember(Name = "unitType", EmitDefaultValue = false)]
        public string UnitType { get; set; }

        [DataMember(Name = "state", EmitDefaultValue = false)]
        public string State { get; set; }

        [DataMember(Name = "postalCode", EmitDefaultValue = false)]
        public string PostalCode { get; set; }

        [DataMember(Name = "city", EmitDefaultValue = false)]
        public string City { get; set; }

        [DataMember(Name = "module", EmitDefaultValue = false)]
        public string Module { get; set; }

        [DataMember(Name = "recordId", EmitDefaultValue = false)]
        public string RecordId { get; set; }

        [DataMember(Name = "recordTypeIds", EmitDefaultValue = false)]
        public List<string> RecordTypeIds { get; set; }


        [DataMember(Name = "status")]
        public string Status { get; set; } 

        public static InspectionCriteria ToEntityModel(WSInspectionFilter criteria)
        {
            InspectionCriteria result = new InspectionCriteria();

            if (criteria != null)
            {
                CultureInfo enUS = new CultureInfo("en-US");
                string[] dateFormats = new string[] { "yyyy-MM-dd", "MM/dd/yyyy" };
                string dateFormatForMeta = "yyyy-MM-dd";

                DateTime today = DateTime.Today;

                if (!String.IsNullOrWhiteSpace(criteria.StartDate)
                    && DateTime.TryParseExact(criteria.StartDate, dateFormats, enUS, DateTimeStyles.None, out today))
                {
                    result.ScheduleDateFrom = today.ToString(dateFormatForMeta);

                    if (String.IsNullOrWhiteSpace(criteria.EndDate))
                    {
                        throw new Exception("endDate is required.");
                    }
                }

                if (!String.IsNullOrWhiteSpace(criteria.EndDate)
                    && DateTime.TryParseExact(criteria.EndDate, dateFormats, enUS, DateTimeStyles.None, out today))
                {
                    result.ScheduleDateTo = today.ToString(dateFormatForMeta);

                    if (String.IsNullOrWhiteSpace(criteria.StartDate))
                    {
                        throw new Exception("startDate is required.");
                    }
                }


                if (!String.IsNullOrWhiteSpace(criteria.ContactFamilyName)
                    || !String.IsNullOrWhiteSpace(criteria.ContactGivenName)
                    || criteria.ContactMiddleNames != null)
                {
                    result.Contacts = new ContactModel
                    {
                        FamilyName = criteria.ContactFamilyName,
                        GivenName = criteria.ContactGivenName,
                        MiddleNames = criteria.ContactMiddleNames
                    };
                }

                if (criteria.Types != null
                    && criteria.Types.Count > 0)
                {
                    result.Types = criteria.Types;
                }


                if (!String.IsNullOrWhiteSpace(criteria.City)
                    || !String.IsNullOrWhiteSpace(criteria.HouseNumber)
                    || !String.IsNullOrWhiteSpace(criteria.HouseNumberFraction)
                    || !String.IsNullOrWhiteSpace(criteria.PostalCode)
                    || !String.IsNullOrWhiteSpace(criteria.State)
                    || !String.IsNullOrWhiteSpace(criteria.StreetDirection)
                    || !String.IsNullOrWhiteSpace(criteria.StreetName)
                    || !String.IsNullOrWhiteSpace(criteria.StreetSuffix)
                    || !String.IsNullOrWhiteSpace(criteria.StreetSuffixDirection)
                    || !String.IsNullOrWhiteSpace(criteria.UnitStart)
                    || !String.IsNullOrWhiteSpace(criteria.UnitEnd)
                    || !String.IsNullOrWhiteSpace(criteria.UnitType))
                {
                    result.Address = new AddressModel()
                    {
                        HouseNumber = criteria.HouseNumber,
                        HouseNumberFraction = criteria.HouseNumberFraction,
                        StreetDirection = criteria.StreetDirection,
                        StreetName = criteria.StreetName,
                        StreetSuffix = criteria.StreetSuffix,
                        StreetSuffixDirection = criteria.StreetSuffixDirection,
                        Unit = criteria.UnitStart,
                        UnitEnd = criteria.UnitEnd,
                        UnitType = criteria.UnitType,
                        State = criteria.State,
                        PostalCode = criteria.PostalCode,
                        City = criteria.City,
                    };
                }

                if (criteria.InspectorIds != null)
                {
                    result.InspectorIds = criteria.InspectorIds;
                }

                result.ParcelId = criteria.ParcelId;
                result.Module = criteria.Module;

                result.RecordId = criteria.RecordId;
                result.RecordTypeIds = criteria.RecordTypeIds;

                result.Status = criteria.Status;
            }

            return result;
        }
    }
}
