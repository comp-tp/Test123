using System.Collections.Generic;
using Accela.Apps.Apis.Models.DomainModels.AdditionalModels;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;
using Accela.Apps.Apis.Models.DTOs.Requests.ReferenceRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses;
using Accela.Automation.GovXmlClient.Model;

namespace Accela.Apps.Apis.Repositories.GovXmlHelpers
{
    public static class RecordTypeHelper
    {
        public static AdditionalGroupModel ToClientAdditionalGroup(AdditionalInformationGroup xmlAdditionalGroup)
        {
            AdditionalGroupModel clientAdditionalGroup = new AdditionalGroupModel();
            clientAdditionalGroup.Identifier = xmlAdditionalGroup.keys.ToStringKeys();
            clientAdditionalGroup.Display = xmlAdditionalGroup.identifierDisplay;
            clientAdditionalGroup.Description = xmlAdditionalGroup.description;

            clientAdditionalGroup.Security = xmlAdditionalGroup.security;

            if (xmlAdditionalGroup.additionalInformationSubGroup != null && xmlAdditionalGroup.additionalInformationSubGroup.Length > 0)
            {
                clientAdditionalGroup.SubGroups = new List<AdditionalSubGroupModel>();
                foreach (AdditionalInformationSubGroup subGroup in xmlAdditionalGroup.additionalInformationSubGroup)
                {
                    clientAdditionalGroup.SubGroups.Add(ASIHelper.ToClientAdditionalSubGroup(clientAdditionalGroup.Identifier, subGroup));
                }
            }

            return clientAdditionalGroup;
        }

        public static RecordTypesResponse ToClientRecordTypes(GetCAPTypesResponse getCAPTypesResponse)
        {
            var result = new RecordTypesResponse();

            if (getCAPTypesResponse.system != null)
            {
                result.PageInfo = CommonHelper.GetPaginationFromSystem(getCAPTypesResponse.system);
                result.Events = CommonHelper.GetClientEventMessage(getCAPTypesResponse.system.eventMessages);
            }

            result.RecordTypes = new List<RecordTypeModel>();

            if (getCAPTypesResponse.capTypes != null
                && getCAPTypesResponse.capTypes.capType != null)
            {
                foreach (var capType in getCAPTypesResponse.capTypes.capType)
                {
                    var recordTypeModel = new RecordTypeModel();
                    recordTypeModel.Identifier = capType.keys.ToStringKeys();
                    recordTypeModel.Display = capType.identifierDisplay;
                    recordTypeModel.Category = capType.Category;
                    recordTypeModel.Group = capType.Group;
                    recordTypeModel.Module = capType.Module;
                    recordTypeModel.SubGroup = capType.SubGroup;
                    recordTypeModel.Type = capType.Type;
                    recordTypeModel.Security = capType.ApplicationTypeSecurity;
                    if (capType.additionalInformationGroupIds != null
                        && capType.additionalInformationGroupIds.additionalInformationGroupId != null
                        && capType.additionalInformationGroupIds.additionalInformationGroupId.Length > 0)
                    {
                        recordTypeModel.AdditionalInformationGroupIds = new List<AdditionalInformationGroupIdModel>();
                        foreach (var aigId in capType.additionalInformationGroupIds.additionalInformationGroupId)
                        {
                            AdditionalInformationGroupIdModel additionalInformationGroupId = new AdditionalInformationGroupIdModel();
                            additionalInformationGroupId.Id = KeysHelper.ToStringKeys(aigId.keys);
                            additionalInformationGroupId.Display = aigId.identifierDisplay;
                            recordTypeModel.AdditionalInformationGroupIds.Add(additionalInformationGroupId);
                        }
                    }

                    //Record Statuses
                    if (capType.dispositions != null
                        && capType.dispositions.disposition != null
                        && capType.dispositions.disposition.Length > 0)
                    {
                        recordTypeModel.RecordStatuses = new List<RecordStatusModel>();
                        foreach (var xmlstatus in capType.dispositions.disposition)
                        {
                            RecordStatusModel clientStatus = new RecordStatusModel();
                            clientStatus.Identifier = KeysHelper.ToStringKeys(xmlstatus.keys);
                            clientStatus.Display = xmlstatus.identifierDisplay;
                            recordTypeModel.RecordStatuses.Add(clientStatus);
                        }
                    }

                    if (capType.inspectionTypeSetIds != null && 
                        capType.inspectionTypeSetIds.inspectionTypeSetId != null && 
                        capType.inspectionTypeSetIds.inspectionTypeSetId.Length > 0)
                    {
                        recordTypeModel.InspectionGroups = new List<string>();
                        foreach(var typeSetId in capType.inspectionTypeSetIds.inspectionTypeSetId)
                        {
                            recordTypeModel.InspectionGroups.Add(KeysHelper.ToStringKeys(typeSetId.keys));
                        }
                    }

                    if (capType.standardCommentsGroups != null &&
                        capType.standardCommentsGroups.standardCommentsGroupIds != null &&
                        capType.standardCommentsGroups.standardCommentsGroupIds.Length > 0)
                    {
                        recordTypeModel.StandardCommentsGroupIds = new List<string>();
                        foreach (var standCommentGroupId in capType.standardCommentsGroups.standardCommentsGroupIds)
                        {
                            recordTypeModel.StandardCommentsGroupIds.Add(KeysHelper.ToStringKeys(standCommentGroupId.keys));
                        }
                    }

                    result.RecordTypes.Add(recordTypeModel);
                }
            }

            return result;
        }

        public static AdditionalGroupResponse ToClientAdditionalGroups(GetAdditionalInformationGroupsResponse getAdditionalInformationGroupsResponse)
        {
            AdditionalGroupResponse results = new AdditionalGroupResponse();

            var xmlObj = getAdditionalInformationGroupsResponse;

            if (xmlObj.additionalInformation != null
                && xmlObj.additionalInformation.additionalInformationGroup != null
                && xmlObj.additionalInformation.additionalInformationGroup.Length > 0)
            {
                results.AdditionalGroups = new List<AdditionalGroupModel>();
                foreach (var additionalGroup in xmlObj.additionalInformation.additionalInformationGroup)
                {
                    results.AdditionalGroups.Add(ToClientAdditionalGroup(additionalGroup));
                }
            }

            return results;
        }
    }
}
