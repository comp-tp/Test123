using System;
using System.Collections.Generic;
using Accela.ACA.WSProxy;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;
using Accela.Apps.Apis.Models.DTOs.Requests.ReferenceRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses;
using Accela.Apps.Shared.Utils;
using Accela.Automation.CitizenServices.Client.Models.Request.Record;
using Accela.Automation.CitizenServices.Client.Models.Response.Record;
using Accela.Apps.Apis.Models.Common;

namespace Accela.Apps.Apis.Repositories.CitizenHelpers
{
    public sealed class CitizenRecordTypeHelper
    {
        private string _serviceProvCode;
        public CitizenRecordTypeHelper(string serviceProvCode)
        {
            _serviceProvCode = serviceProvCode;
        }

        public static RecordTypesResponse GetRecordTypesModel(CitizenGetRecordTypeResponse citizenRecordTypesResponse)
        {
            var recordTypesResponse = new RecordTypesResponse();
            recordTypesResponse.RecordTypes = new List<RecordTypeModel>();
            if (citizenRecordTypesResponse != null &&
                citizenRecordTypesResponse.result != null &&
                citizenRecordTypesResponse.result.Count > 0)
            {
                foreach (var citizenRecordType in citizenRecordTypesResponse.result)
                {
                    recordTypesResponse.RecordTypes.Add(ToClientEntity(citizenRecordType));
                }
            }
            return recordTypesResponse;
        }

        public static CitizenGetRecordTypeRequest GetCitizenRecordTypeRequest(RecordTypesRequest recordTypeRequest)
        {
            return new CitizenGetRecordTypeRequest()
            {
                module = recordTypeRequest.Module
            };
        }

        public static RecordTypeModel ToClientEntity(CapTypeModel citizenModel)
        {
            RecordTypeModel recordTypeModel = null;

            if (citizenModel != null)
            {
                recordTypeModel = new RecordTypeModel()
                {
                    Identifier = BuildID(citizenModel),
                    Display = citizenModel.alias,
                    Module = citizenModel.moduleName,
                    Group = citizenModel.group,
                    SubGroup = citizenModel.subType,
                    Category = citizenModel.category,
                    Type = citizenModel.type
                };
            }

            return recordTypeModel;
        }

        private static string BuildID(CapTypeModel citizenModel)
        {
            string result = String.Empty;

            if (citizenModel != null)
            {
                result = String.Format("{0}-{1}-{2}-{3}", IdEscapeHelper.EncodeString(citizenModel.group), IdEscapeHelper.EncodeString(citizenModel.type), IdEscapeHelper.EncodeString(citizenModel.subType), IdEscapeHelper.EncodeString(citizenModel.category));
            }

            return result;
        }

        public CapTypeModel ToCitizenRecordType(RecordTypeModel entityRecordType)
        {
            CapTypeModel result = new CapTypeModel();

            if (entityRecordType != null
                && !String.IsNullOrWhiteSpace(entityRecordType.Identifier))
            {
                string[] types = entityRecordType.Identifier.Split('-');

                if (types != null
                    && types.Length == 4)
                {
                    result.group = IdEscapeHelper.DecodeString(types[0]);
                    result.type = IdEscapeHelper.DecodeString(types[1]);
                    result.subType = IdEscapeHelper.DecodeString(types[2]);
                    result.category = IdEscapeHelper.DecodeString(types[3]);
                }

                result.serviceProviderCode = _serviceProvCode;
            }

            return result;
        }
    }
}
