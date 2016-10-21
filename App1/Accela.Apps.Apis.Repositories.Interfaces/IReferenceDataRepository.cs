﻿
using Accela.Apps.Apis.Models.DTOs.Responses.InspectionResponses;
using Accela.Apps.Apis.Models.DTOs.Requests.InspectionRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses;
using Accela.Apps.Apis.Models.DTOs.Requests.ReferenceRequests;
using Accela.Apps.Apis.Models.DTOs.Requests.AttachmentRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.AttachmentResponses;
using Accela.Apps.Apis.Models.DTOs.Responses.AssetResponse;
using Accela.Apps.Apis.Models.DTOs.Requests.AssetRequests;
using Accela.Apps.Apis.Models.DTOs.Requests.InspectorRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.InspectorResponses;
using Accela.Apps.Apis.Models.DTOs.Responses.Departments;
using Accela.Apps.Apis.Models.DTOs.Requests.Departments;
using Accela.Apps.Apis.Models.DTOs.Requests.ReferenceRequests.Contact;
using Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses.Contact;
using Accela.Apps.Apis.Models.DTOs.Responses.StandardChoicesResponses;
using System.Collections.Generic;
namespace Accela.Apps.Apis.Repositories.Interfaces
{
    public interface IReferenceDataRepository : IRepository
    {
        /// <summary>
        /// Get inspection type list.
        /// </summary>
        /// <param name="user">a Cloud User.</param>
        /// <param name="pageIndex">page start Index</param>
        /// <param name="pageSize">Number of items to return in paged collection</param>
        /// <returns>InspectionTypeModel list.</returns>
        InspectionTypeResponse GetInspetionTypes(InspectionTypeRequest request);

        /// <summary>
        /// Gets the inspetion statuses.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="inspectionTypeId">The inspection type id.</param>
        /// <returns>the inspetion statuses.</returns>
        InspectionStatusResponse GetInspetionStatuses(InspectionStatusRequest request);

        /// <summary>
        /// Gets the standard comment groups.
        /// </summary>
        /// <param name="cloudUser">The cloud user.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>the standard comment groups.</returns>
        StandardCommentGroupResponse GetStandardCommentGroups(StandardCommentGroupRequest request);

        /// <summary>
        /// Gets the standard comments.
        /// </summary>
        /// <param name="cloudUser">The cloud user.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>the standard comments.</returns>
        StandardCommentResponse GetStandardComments(StandardCommentRequest request);

        /// <summary>
        /// Gets the departments.
        /// </summary>
        /// <param name="cloudUser">The cloud user.</param>
        /// <returns>the departments.</returns>
        DepartmentResponse GetDepartments(DepartmentRequest request);

        /// <summary>
        /// Gets the inspectors.
        /// </summary>
        /// <param name="cloudUser">The cloud user.</param>
        /// <param name="departmentId">The department id.</param>
        /// <returns>the inspectors.</returns>
        InspectorResponse GetInspectors(InspectorRequest request);

        /// <summary>
        /// Get Standard commment. remove cache
        /// </summary>
        /// <param name="request">standard comment request</param>
        /// <returns></returns>
        StandardCommentResponse GetStandardCommentsNoCache(StandardCommentRequest request);

        /// <summary>
        /// Get insepction types
        /// didn't get from cache
        /// </summary>
        /// <param name="request">inspection type request</param>
        /// <returns>return matched inspecton type</returns>
        InspectionTypeResponse GetInspetionTypesNoCache(InspectionTypeRequest request);

        /// <summary>
        /// Get Additionals
        /// </summary>
        /// <param name="request">request for additional</param>
        /// <returns>return all additionals</returns>
        AdditionalResponse GetAdditionals(AdditionalRequest request);

        /// <summary>
        /// Gets the owners.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>the owners.</returns>
        OwnersResponse GetOwners(OwnersRequest request);

        /// <summary>
        /// Gets the record types.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>the record types.</returns>
        RecordTypesResponse GetRecordTypes(RecordTypesRequest request);

        /// <summary>
        /// Get Attachment type
        /// </summary>
        /// <param name="request">The request</param>
        /// <returns>the attachment TYPE</returns>
        DocumentTypesResponse GetDocumentTypes(DocumentTypeRequest request);

        /// <summary>
        /// Get all additionalGroups
        /// </summary>
        /// <param name="request">The request</param>
        /// <returns>return all additionalGroups</returns>
        AdditionalGroupResponse GetAdditionalGroups(AdditionalGroupRequest request);

        /// <summary>
        /// Get the system address street prefixes
        /// </summary>
        /// <param name="request">The request</param>
        /// <returns>Return all street prefixes</returns>
        StreetPrefixesResponse GetStreetPrefixes(StreetPrefixesRequest request);

        /// <summary>
        /// Gets the asset statuses.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>the asset statuses.</returns>
        AssetStatusesResponse GetAssetStatuses(AssetStatusesRequest request);

        AssetTypesResponse GetAssetTypes(AssetTypesRequest request);

        /// <summary>
        /// Gets the asset unit types.
        /// </summary>
        /// <param name="request">The request</param>
        /// <returns>the asset unit types</returns>
        AssetUnitTypesResponse GetAssetUnitTypes(AssetUnitTypesRequest request);

        StandardChoicesResponse GetStandardChoices(GetStandardChoicesRequest request);
        
        /// <summary>
        /// Get the AssetCA Types
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        AssetCATypesResponse GetAssetCATypes(GetAssetCATypesRequest request);

        /// <summary>
        /// Gets the asset ASIs.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>the asset ASIs.</returns>
        AdditionalResponse GetAssetASIs(AssetASIsRequest request);

        /// <summary>
        /// Gets the asset ASITs.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>the asset ASITs.</returns>
        AdditionalTableResponse GetAssetASITs(AssetASITsRequest request);

        RecordPrioritiesResponse GetRecordPriorities(RecordPrioritiesRequest request);

        /// <summary>
        /// Gets the modules of agency.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>modules response</returns>
        ModulesResponse GetModules(ModulesRequest request);

        /// <summary>
        /// get active system Inspectors 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        SystemInspectorResponse GetSystemInspectors(SystemInspectorRequest request);



        /// <summary>
        /// get the system departments and its all staffs every department.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        SystemDepartmentsResponse GetSystemDepartments(SystemDepartmentsRequest request);


        /// <summary>
        /// get a department's all staffs. 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        SystemDepartmentStaffsResponse GetSystemDepartmentStaffs(SystemDepartmentStaffsRequest request);


        /// <summary>
        /// Gets the inspection groups.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>the inspection groups.</returns>
        InspectionGroupResponse GetInspectionGroups(InspectionGroupRequest request);

        /// <summary>
        /// get the inspection group's all types.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        SystemInspectionTypeResponse GetSystemInspectionTypes(SystemInspectionTypeRequest request);


        /// <summary>
        ///  get the workorder's templates
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        WorkOrderTemplateResponse GetWorkOrderTemplates(WorkOrderTemplateRequest request);

        SystemContactTypesResponse GetContactTypes(SystemContactTypesRequest request);

        RecordStatusesResponse GetRecordDispositions(RecordStatusesRequest request);
    }
}
