using System;
using System.Collections.Generic;
using System.Linq;
using Accela.ACA.WSProxy;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;
using Accela.Apps.Apis.Models.DTOs.Requests.RecordRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.RecordResponses;
using Accela.Apps.Apis.Repositories.Citizen;
using Accela.Automation.CitizenServices.Client.Models.Request.Record;
using Accela.Automation.CitizenServices.Client.Models.Response.Record;
using Accela.Apps.Apis.Repositories.Citizen.CitizenHelpers;

namespace Accela.Apps.Apis.Repositories.CitizenHelpers
{
    public class CitizenRecordHelper
    {
        private string _agencgName;
        private string _serviceProvCode;
        public CitizenRecordHelper(string agencyName, string serviceProvCode)
        {
            _agencgName = agencyName;
            _serviceProvCode = serviceProvCode;
        }

        public CitizenCreateRecordRequest ToCitizenCreateRecord(CreateRecordRequest entityRequest)
        {
            CitizenCreateRecordRequest request = new CitizenCreateRecordRequest();

            if (entityRequest != null
                && entityRequest.Record != null)
            {
                var recordModel = entityRequest.Record;

                if (recordModel != null)
                {
                    if (recordModel.RecordType != null)
                    {
                        CitizenRecordTypeHelper helper = new CitizenRecordTypeHelper(_serviceProvCode);
                        request.capType = helper.ToCitizenRecordType(recordModel.RecordType);
                    }

                    if (!String.IsNullOrWhiteSpace(recordModel.OpenDate))
                    {
                        request.fileDate = CommonHelper.ToCitizenDateTimeString(recordModel.OpenDate);
                    }

                    if (!String.IsNullOrWhiteSpace(recordModel.Description))
                    {
                        request.capWorkDesModel = CitizenRecordWorkDescriptionHelper.ToCitizenRecordWorkDescription(recordModel.Description);
                    }

                    request.capDetailModel = new CapDetailModel();

                    if (recordModel.ScheduleDate != null)
                    {
                        request.capDetailModel.scheduledDate = CommonHelper.ToACAISODateString(recordModel.ScheduleDate.Trim());
                    }

                    if (recordModel.ScheduleTime != null)
                    {
                        request.capDetailModel.scheduledTime = CommonHelper.ToACAISOTimeString(recordModel.ScheduleTime.Trim());
                    }

                    request.capDetailModel.priority = recordModel.Priority;

                    request.capDetailModel.asgnDate = CommonHelper.ToACAISODateString(recordModel.AssignDate);

                    if (recordModel.Addresses != null
                        && recordModel.Addresses.Count > 0)
                    {
                        CitizenAddressHelper helper = new CitizenAddressHelper(_serviceProvCode);
                        request.addressModel = helper.ToCitizenAddress(recordModel.Addresses[0]);
                    }

                    if (recordModel.Parcels != null && recordModel.Parcels.Count > 0)
                    {
                        request.parcelModel = CitizenParcelHelper.ToACACapParcelModel(recordModel.Parcels[0], this._serviceProvCode);
                    }

                    if (recordModel.Contacts != null)
                    {
                        CitizenContactModelHelper helper = new CitizenContactModelHelper(_serviceProvCode);
                        request.contactsGroup = helper.ToCitizenContacts(recordModel.Contacts);
                    }

                    if (recordModel.Owners != null
                        && recordModel.Owners.Count > 0)
                    {
                        CitizenContactModelHelper helper = new CitizenContactModelHelper(_serviceProvCode);
                        request.ownerModel = helper.ToCitizenOwner(recordModel.Owners[0]);
                    }
                }
            }

            return request;
        }

        public static RecordsResponse GetRecordByIdResponse(CitizenGetRecordByIdResponse citizenGetRecordByIdResponse)
        {
            RecordsResponse recordsResponse = new RecordsResponse();
            recordsResponse.Records = new List<RecordModel>();
            if (citizenGetRecordByIdResponse != null && citizenGetRecordByIdResponse.result != null)
            {
                var RecordModel = ToClientRecord(citizenGetRecordByIdResponse.result);
                recordsResponse.Records.Add(RecordModel);
            }

            SortByOpenDateDesc(recordsResponse);

            return recordsResponse;
        }

        /// <summary>
        /// Sort by OpenDate Desc.
        /// </summary>
        /// <param name="citizenRecordModel"></param>
        /// <returns></returns>
        public static RecordsResponse GetRecordByIdResponse(CapModel4WS citizenRecordModel)
        {
            RecordsResponse recordsResponse = new RecordsResponse();
            recordsResponse.Records = new List<RecordModel>();
            if (citizenRecordModel != null)
            {
                var RecordModel = ToClientRecord(citizenRecordModel);
                recordsResponse.Records.Add(RecordModel);
            }
            return recordsResponse;
        }

        private static void SortByOpenDateDesc(RecordsResponse response)
        {
            if (response != null && response.Records != null)
            {
                response.Records = response.Records.OrderByDescending(item => item.OpenDate).ToList();
            }
        }

        private static RecordModel ToClientRecord(CapModel4WS citizenRecordModel)
        {
            var recordModel = new RecordModel();
            recordModel.Identifier = BuildID4Entity(citizenRecordModel.capID);
            recordModel.RecordType = CitizenRecordTypeHelper.ToClientEntity(citizenRecordModel.capType);
            recordModel.Display = citizenRecordModel.altID;
            recordModel.Name = citizenRecordModel.specialText;
            recordModel.Module = citizenRecordModel.moduleName;
            recordModel.OpenDate = citizenRecordModel.fileDate;
            if (citizenRecordModel.capDetailModel != null)
            {
                recordModel.ScheduleDate = CommonHelper.ToUTCDateString(citizenRecordModel.capDetailModel.scheduledDate);
                recordModel.ScheduleTime = citizenRecordModel.capDetailModel.scheduledTime;
                recordModel.Priority = citizenRecordModel.capDetailModel.priority;

                recordModel.AssignDate = CommonHelper.ToUTCDateTimeString(citizenRecordModel.capDetailModel.asgnDate);

                recordModel.RecordStatus = new RecordStatusModel();

                recordModel.RecordStatus.Identifier = citizenRecordModel.capStatus;
                recordModel.RecordStatus.Display = citizenRecordModel.capStatus;

                if (!string.IsNullOrWhiteSpace(citizenRecordModel.capDetailModel.asgnDept))
                {
                    recordModel.Department = new DepartmentModel();
                    recordModel.Department.Identifier = citizenRecordModel.capDetailModel.asgnDept;
                    recordModel.Department.Display = citizenRecordModel.capDetailModel.asgnDept;
                }

                if (!string.IsNullOrWhiteSpace(citizenRecordModel.capDetailModel.asgnStaff))
                {
                    recordModel.StaffPerson = new StaffPersonModel();
                    recordModel.StaffPerson.Identifier = citizenRecordModel.capDetailModel.asgnStaff;
                    recordModel.StaffPerson.Display = citizenRecordModel.capDetailModel.asgnStaff;
                }
            }

            if (citizenRecordModel.capWorkDesModel != null)
            {
                recordModel.Description = citizenRecordModel.capWorkDesModel.description;
            }

            return recordModel;
        }

        internal static CreateRecordResponse ToEnityModel(CitizenCreateRecordResponse citizenResponse)
        {
            CreateRecordResponse response = new CreateRecordResponse();

            if (citizenResponse != null)
            {
                if (citizenResponse.result != null)
                {
                    response.RecordId = new RecordIdModel
                    {
                        Identifier = BuildID4Entity(citizenResponse.result.capID),
                        Display = citizenResponse.result.capID.customID
                    };

                    response.OpenDate = citizenResponse.result.fileDate;
                }
  
            }
            return response;
        }

        public static string BuildID4Entity(CapIDModel4WS capIdModel)
        {
            string result = null;
            var pattern = "{0}-{1}-{2}";

            if (capIdModel != null)
            {
                result = String.Format(pattern
                    , capIdModel.id1
                    , capIdModel.id2
                    , capIdModel.id3);
            }

            return result;
        }
    }
}
