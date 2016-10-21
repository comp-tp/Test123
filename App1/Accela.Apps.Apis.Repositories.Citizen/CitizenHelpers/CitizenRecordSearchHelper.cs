using System;
using Accela.Apps.Apis.Models.DTOs.Requests.RecordRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.RecordResponses;
using Accela.Apps.Shared.FormatHelpers;
using Accela.Automation.CitizenServices.Client.Models.Request.Record;
using Accela.Automation.CitizenServices.Client.Models.Response.Record;
using Accela.ACA.WSProxy;
using System.Collections.Generic;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;

namespace Accela.Apps.Apis.Repositories.CitizenHelpers
{
    public class CitizenRecordSearchHelper
    {
        /// <summary>
        /// Converts to the search records by address citizen request.
        /// </summary>
        /// <param name="entityModel">The entity model.</param>
        /// <returns>CitizenSearchRecordsByAddressRequest</returns>
        public static CitizenSearchRecordsByAddressRequest ToCitizenRequestByAddress(RecordsRequest entityModel)
        {
            CitizenSearchRecordsByAddressRequest result = null;

            if (entityModel != null && entityModel.Criteria != null && entityModel.Criteria.Address != null)
            {
                var entityCriteria = entityModel.Criteria.Address;
                result = new CitizenSearchRecordsByAddressRequest()
                {
                    city = entityCriteria.City,
                    houseNumberStart = entityCriteria.HouseNumber,
                    state = entityCriteria.State,
                    streetName = entityCriteria.StreetName,
                    zip = entityCriteria.ZipCode
                };
            }

            return result;
        }

        /// <summary>
        /// Converts to the search records by contact citizen request.
        /// </summary>
        /// <param name="entityModel">The entity model.</param>
        /// <returns>CitizenSearchRecordsByContactRequest</returns>
        public static CitizenSearchRecordsByContactRequest ToCitizenRequestByContact(RecordsRequest entityModel)
        {
            CitizenSearchRecordsByContactRequest result = null;

            if (entityModel != null && entityModel.Criteria != null && entityModel.Criteria.Contact != null)
            {
                var entityCriteria = entityModel.Criteria.Contact;
                result = new CitizenSearchRecordsByContactRequest()
                {
                    firstName = entityCriteria.FirstName,
                    lastName = entityCriteria.LastName,
                    middleName = entityCriteria.MiddleName,
                    name = entityCriteria.PersonName
                };
            }

            return result;
        }

        /// <summary>
        /// Converts to the search records by record citizen request.
        /// </summary>
        /// <param name="entityModel">The entity model.</param>
        /// <returns>CitizenSearchRecordsByRecordRequest</returns>
        public static CitizenSearchRecordsByRecordRequest ToCitizenRequestByRecord(RecordsRequest entityModel, string serviceProviderCode)
        {
            CitizenSearchRecordsByRecordRequest result = null;

            if (entityModel != null && entityModel.Criteria != null)
            {
                var entityCriteria = entityModel.Criteria;
                var recordTypeId = entityCriteria.RecordTypeIds != null && entityCriteria.RecordTypeIds.Count > 0 ? entityCriteria.RecordTypeIds[0] : null;
                result = new CitizenSearchRecordsByRecordRequest()
                {
                    /* Implementation Notes:
                     
                     We are using ACA Lighting Service.
                     It is based on ACA business logic and because ACA is a ASP.NET website. 
                     So the dete format it required looks like this: "MM/dd/yyyy HH:mm:ss"
                     
                     In our implementation, we treat this format as "UIDate" format.
                    // */
                    fileDate = !string.IsNullOrWhiteSpace(entityCriteria.OpenedDateFrom) ? DateTimeFormat.ToUIDateStringFromMetaDateString(entityCriteria.OpenedDateFrom) : null,
                    endFileDate = !string.IsNullOrWhiteSpace(entityCriteria.OpenedDateTo) ? DateTimeFormat.ToUIDateStringFromMetaDateString(entityCriteria.OpenedDateTo) : null,
                    altID = entityCriteria.Displays != null && entityCriteria.Displays.Count > 0 ? entityCriteria.Displays[0] : null,
                    addressModel = ToCitizenRequestByAddress(entityModel),
                    capContactModel = ToCitizenRequestByContact(entityModel),
                    capType = BuildRecordTypeModel(recordTypeId, serviceProviderCode, entityCriteria.Module)
                };
            }

            return result;
        }

        /// <summary>
        /// Converts to the entity response.
        /// </summary>
        /// <param name="citizenModel">The citizen model.</param>
        /// <returns>RecordsResponse</returns>
        public static RecordsResponse ToEntityResponse(CitizenSearchRecordsResponse citizenModel, bool IncludeAddresses)
        {
            RecordsResponse result = null;

            if (citizenModel != null)
            {
                result = new RecordsResponse();
                result.Records = CitizenSimpleRecordHelper.ToEntities4Search(citizenModel.result, IncludeAddresses);
            }

            return result;
        }

        public static CapTypeModel BuildRecordTypeModel(string recordTypeId, string serviceProviderCode, string module)
        {
            CapTypeModel result = null;

            if (!String.IsNullOrEmpty(recordTypeId))
            {
                var recordTypeModel = new RecordTypeModel()
                {
                    Identifier = recordTypeId
                };
                CitizenRecordTypeHelper helper = new CitizenRecordTypeHelper(serviceProviderCode);
                result = helper.ToCitizenRecordType(recordTypeModel);
                result.moduleName = module;
            }

            return result;
        }
    }
}
