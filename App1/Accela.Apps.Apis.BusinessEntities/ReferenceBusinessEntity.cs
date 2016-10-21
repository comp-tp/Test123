using System.Collections.Generic;
using System.Linq;
using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Models.DomainModels.AdditionalModels;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;
using Accela.Apps.Apis.Models.DTOs.Requests.AssetRequests;
using Accela.Apps.Apis.Models.DTOs.Requests.AttachmentRequests;
using Accela.Apps.Apis.Models.DTOs.Requests.Departments;
using Accela.Apps.Apis.Models.DTOs.Requests.InspectionRequests;
using Accela.Apps.Apis.Models.DTOs.Requests.InspectorRequests;
using Accela.Apps.Apis.Models.DTOs.Requests.ReferenceRequests;
using Accela.Apps.Apis.Models.DTOs.Requests.ReferenceRequests.Contact;
using Accela.Apps.Apis.Models.DTOs.Responses.AssetResponse;
using Accela.Apps.Apis.Models.DTOs.Responses.AttachmentResponses;
using Accela.Apps.Apis.Models.DTOs.Responses.Departments;
using Accela.Apps.Apis.Models.DTOs.Responses.InspectionResponses;
using Accela.Apps.Apis.Models.DTOs.Responses.InspectorResponses;
using Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses;
using Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses.Contact;
using Accela.Apps.Apis.Repositories.Interfaces;
using Accela.Apps.Shared;
using Accela.Apps.Apis.Models.DTOs.Responses.StandardChoicesResponses;
using Accela.Core.Ioc;

namespace Accela.Apps.Apis.BusinessEntities
{
    public class ReferenceBusinessEntity : IReferenceBusinessEntity
    {
        
        public ReferenceBusinessEntity(IReferenceDataRepository referenceDataRepository)
        {
            //todo:
            //this.ASISecurityBusinessEntity = asiSecurityBusinessEntity;
            this.ReferenceDataRepository = referenceDataRepository;
        }



        private IASISecurityBusinessEntity _asiSecurityBusinessEntity = null;
        private  IASISecurityBusinessEntity ASISecurityBusinessEntity
        {
            get
            {
                if (_asiSecurityBusinessEntity == null)
                {
                    //Dictionary<string, object> ctorParams = MakeConstructorParameters();
                    _asiSecurityBusinessEntity = IocContainer.Resolve<IASISecurityBusinessEntity>();
                }

                return _asiSecurityBusinessEntity;
            }
        }

        private readonly IReferenceDataRepository ReferenceDataRepository;


        /// <summary>
        /// Get inspection type list.
        /// </summary>
        /// <param name="cloudUser">a Cloud User.</param>
        /// <param name="pageIndex">Page start Index</param>
        /// <param name="pageSize">Number of items to return in paged collection</param>
        /// <returns>InspectionTypeModel list.</returns>
        public InspectionTypeResponse GetInspetionTypes(InspectionTypeRequest request)
        {
            return ReferenceDataRepository.GetInspetionTypes(request);
        }

        /// <summary>
        /// Gets the inspection statuses.
        /// </summary>
        /// <param name="cloudUser">The cloud user.</param>
        /// <param name="inspectionTypeId">The inspection type id.</param>
        /// <returns>
        /// the inspection statuses.
        /// </returns>
        public InspectionStatusResponse GetInspetionStatuses(InspectionStatusRequest request)
        {
            return ReferenceDataRepository.GetInspetionStatuses(request);
        }

        /// <summary>
        /// Gets the standard comment groups.
        /// </summary>
        /// <param name="cloudUser">The cloud user.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>the standard comment groups.</returns>
        public StandardCommentGroupResponse GetStandardCommentGroups(StandardCommentGroupRequest request)
        {
            return ReferenceDataRepository.GetStandardCommentGroups(request);
        }

        /// <summary>
        /// Gets the standard comments.
        /// </summary>
        /// <param name="cloudUser">The cloud user.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>the standard comments.</returns>
        public StandardCommentResponse GetStandardComments(StandardCommentRequest request)
        {
            return ReferenceDataRepository.GetStandardComments(request);
        }

        /// <summary>
        /// Gets the departments with inspectors.
        /// </summary>
        /// <param name="cloudUser">The cloud user.</param>
        /// <returns>
        /// the departments with inspectors.
        /// </returns>
        public DepartmentResponse GetDepartments(DepartmentRequest request)
        {
            return ReferenceDataRepository.GetDepartments(request);
        }

        /// <summary>
        /// Gets the inspectors.
        /// </summary>
        /// <param name="cloudUser">The cloud user.</param>
        /// <param name="departmentId">The department id.</param>
        /// <returns>the inspectors.</returns>
        public InspectorResponse GetInspectors(InspectorRequest request)
        {
            return ReferenceDataRepository.GetInspectors(request);
        }

        /// <summary>
        /// Get standard comment from repository
        /// </summary>
        /// <param name="request">standard comment request</param>
        /// <returns>matched standard comment</returns>
        public StandardCommentResponse GetStandardCommentsNoCache(StandardCommentRequest request)
        {
            return ReferenceDataRepository.GetStandardCommentsNoCache(request);
        }

        /// <summary>
        /// Get inspection type list.
        /// </summary>
        /// <param name="cloudUser">a Cloud User.</param>
        /// <param name="pageIndex">Page start Index</param>
        /// <param name="pageSize">Number of items to return in paged collection</param>
        /// <returns>InspectionTypeModel list.</returns>
        public InspectionTypeResponse GetInspetionTypesNoCache(InspectionTypeRequest request)
        {
            return ReferenceDataRepository.GetInspetionTypesNoCache(request);
        }


        public AdditionalResponse GetAdditionals(AdditionalRequest request)
        {
            var addtionalResponse = ReferenceDataRepository.GetAdditionals(request);

            ASISecurityBusinessEntity.RemoveASIInvisableItems(addtionalResponse.Additionals);

            return addtionalResponse;
        }


        public List<AdditionalTableModel> GetAdditionalTableByGroup(AdditionalGroupModel request)
        {
            List<AdditionalTableModel> results = null;
            if (request != null)
            {

                results = new List<AdditionalTableModel>();
                foreach (var subGroup in request.SubGroups)
                {
                    AdditionalTableModel table = new AdditionalTableModel();
                    table.Identifier = request.Identifier;
                    table.SubIdentifier = subGroup.Identifier;
                    table.Display = request.Display;
                    table.SubDisplay = subGroup.Display;
                    table.Description = request.Description;

                    table.Security = subGroup.Security;
                    table.DrillDownSeries = subGroup.DrillDownSeries;

                    table.SubAlias = subGroup.Alias;

                    table.Columns = new List<AdditionalColumnModel>();
                    foreach (var item in subGroup.Items)
                    {
                        AdditionalColumnModel column = new AdditionalColumnModel();
                        column.Identifier = item.Identifier;
                        column.Display = item.Display;
                        column.Name = item.Name;
                        column.Type = item.Type;
                        column.Enumerations = item.Enumerations;
                        column.DefaultValue = item.DefaultValue;
                        column.MinValue = item.MinValue;
                        column.MaxValue = item.MaxValue;
                        column.InputRequired = item.InputRequired;
                        column.Security = item.Security;
                        column.Readonly = item.Readonly;
                        column.UnitOfMeasurement = item.UnitOfMeasurement;
                        column.IsDrillDown = item.IsDrillDown;
                        column.IsDrillDownRoot = item.IsDrillDownRoot;
                        column.DrillDownId = item.DrillDownId;
                        table.Columns.Add(column);
                    }

                    results.Add(table);
                }
            }

            return results;
        }

        /// <summary>
        /// Gets the owners.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>the owners.</returns>
        public OwnersResponse GetOwners(OwnersRequest request)
        {
            return ReferenceDataRepository.GetOwners(request);
        }

        /// <summary>
        /// Gets the record types.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// the record types.
        /// </returns>
        public RecordTypesResponse GetRecordTypes(RecordTypesRequest request)
        {
            return ReferenceDataRepository.GetRecordTypes(request);
        }

        /// <summary>
        /// Query Additionals according request's typeId
        /// </summary>
        /// <param name="request">Additional Request Object, include typeId field</param>
        /// <returns>return matched Additionals</returns>
        public AdditionalResponse GetRecordTypeAdditionals(AdditionalRequest request)
        {
            return GetRecordTypeAdditionals(request, true);
        }
        
        public AdditionalResponse GetAllRecordTypeAdditionals(AdditionalRequest request)
        {
            return GetRecordTypeAdditionals(request, false);
        }

        private AdditionalResponse GetRecordTypeAdditionals(AdditionalRequest request, bool applySecurity)
        {
            AdditionalResponse response = new AdditionalResponse();
            List<string> ids = GetAdditionalInformationGroupIds(request.RelatedId);
            
            //the first additional group is record type's asi
            //other additional group are record type's asits
            if (ids != null && ids.Count > 0)
            {
                ids = new List<string> {ids[0]};
                
                List<AdditionalGroupModel> additionalGroups = GetAdditionalGroups(ids);

                if (applySecurity)
                {
                    ASISecurityBusinessEntity.RemoveASIInvisableItems(additionalGroups);
                }
                
                response.Additionals = additionalGroups;
            }

            return response;
        }

        /// <summary>
        /// Query AdditionalTables according request's typeId
        /// </summary>
        /// <param name="request">AdditionalTable Request Object, include typeId field</param>
        /// <returns>return matched AdditionalTables</returns>
        public AdditionalTableResponse GetRecordTypeAdditionalTables(AdditionalTableRequest request)
        {
            return GetRecordTypeAdditionalTables(request, true);
        }

        public AdditionalTableResponse GetAllRecordTypeAdditionalTables(AdditionalTableRequest request)
        {
            return GetRecordTypeAdditionalTables(request, false);
        }

        private AdditionalTableResponse GetRecordTypeAdditionalTables(AdditionalTableRequest request, bool applySecurity)
        {
            AdditionalTableResponse response = new AdditionalTableResponse();

            List<string> ids = GetAdditionalInformationGroupIds(request.RelatedId);
            
            //the first additional group is record type's asi
            //other additional group are record type's asits
            if (ids != null && ids.Count > 0)
            {
                ids.RemoveAt(0);
            
                List<AdditionalGroupModel> additionalGroups = GetAdditionalGroups(ids);

                response.AdditionalTables = new List<AdditionalTableModel>();
                
                foreach (AdditionalGroupModel group in additionalGroups)
                {
                    response.AdditionalTables.AddRange(GetAdditionalTableByGroup(group));
                }
            }

            if (applySecurity)
            {
                ASISecurityBusinessEntity.RemoveASITInvisableItems(response.AdditionalTables);
            }
            
            return response;
        }



        /// <summary>
        /// get active system Inspectors 
        /// </summary>
        public SystemInspectorResponse GetSystemInspectors(SystemInspectorRequest request)
        {
            return ReferenceDataRepository.GetSystemInspectors(request);

        }

        /// <summary>
        /// Get additionalInformationGroupIds according record type id
        /// </summary>
        /// <param name="system">system info</param>
        /// <param name="curUser">current user</param>
        /// <param name="typeId">record type id</param>
        /// <returns>return matched additionalInformationGroupIds</returns>
        private List<string> GetAdditionalInformationGroupIds(string typeId)
        {
            RecordTypeModel recordType = null;
            RecordTypesRequest request = new RecordTypesRequest();
            request.Module = GetModuleByRecordTypeId(typeId);
            RecordTypesResponse recordTypesResponse = GetRecordTypes(request);
            if (recordTypesResponse.RecordTypes != null && recordTypesResponse.RecordTypes.Count > 0)
                recordType = recordTypesResponse.RecordTypes.Find(f => f.Identifier == typeId);

            List<string> results = new List<string>();
            if (recordType != null && recordType.AdditionalInformationGroupIds != null &&
                recordType.AdditionalInformationGroupIds.Count > 0)
            {
                foreach (AdditionalInformationGroupIdModel idModel in recordType.AdditionalInformationGroupIds)
                {
                    results.Add(idModel.Id);
                }
            }

            return results;
        }

        /// <summary>
        /// Get additionalGroups according ids
        /// </summary>
        /// <param name="system">system info</param>
        /// <param name="curUser">current user</param>
        /// <param name="ids">additionalGroup Ids</param>
        /// <returns>return matched additionalGroups</returns>
        private List<AdditionalGroupModel> GetAdditionalGroups(List<string> ids)
        {
            List<AdditionalGroupModel> results = new List<AdditionalGroupModel>();
            AdditionalGroupRequest addiGroupRequest = new AdditionalGroupRequest();
            AdditionalGroupResponse addiGroupResponse = ReferenceDataRepository.GetAdditionalGroups(addiGroupRequest);

            if (addiGroupResponse.AdditionalGroups != null && addiGroupResponse.AdditionalGroups.Count > 0)
                results = addiGroupResponse.AdditionalGroups.FindAll(f => ids.Contains(f.Identifier));

            return results;
        }

        /// <summary>
        /// Get record status by record type
        /// </summary>
        /// <param name="request">parameter, the field include record type</param>
        /// <returns></returns>
        public RecordStatusesResponse GetRecordStatusByType(RecordStatusesRequest request)
        {
            /**
             * It takes 3 steps to remove the disable status from the list of Record Status.
             * Step 1: Fetch a list of record status in the given record type. Note that GovXML returns both enabled and disabled status in this method.
             * Step 2: Fetch a list of all enabled record status in AA. Note that only the enabled status will be returned in this method.
             * Step 3: Products the set intersection of the above two sequences.
            //*/

            var results = new RecordStatusesResponse {RecordStatuses = new List<RecordStatusModel>()};

            var typeRequest = new RecordTypesRequest
            {
                Module = GetModuleByRecordTypeId(request.RecordTypeId)
            };

            var recordType = ReferenceDataRepository.GetRecordTypes(typeRequest);
            var recordDisposition = ReferenceDataRepository.GetRecordDispositions(request);

            if (recordType == null || recordType.RecordTypes == null || recordDisposition == null || recordDisposition.RecordStatuses == null)
                return results;

            var type = recordType.RecordTypes.SingleOrDefault((o => o.Identifier == request.RecordTypeId));

            if (type == null || type.RecordStatuses == null) return results;
            
            var statuses = type.RecordStatuses.Intersect(recordDisposition.RecordStatuses);

            results.RecordStatuses = statuses.ToList();

            return results;
        }

        private string GetModuleByRecordTypeId(string recordTypeId)
        {
            string retu = null;
            if (!string.IsNullOrWhiteSpace(recordTypeId))
            {
                string[] tems = recordTypeId.Split("-".ToCharArray());
                if (tems.Length > 0 && !string.IsNullOrWhiteSpace(tems[0]))
                {
                    retu = tems[0].Trim();
                }
            }

            return retu;
        }

        /// <summary>
        /// Get Attachment type by Attachment
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public DocumentTypesResponse GetDocumentType(DocumentTypeRequest request)
        {
            DocumentTypeRequest typeRequest = new DocumentTypeRequest();
            DocumentTypesResponse typeResponse = ReferenceDataRepository.GetDocumentTypes(typeRequest);

            return typeResponse;
        }

        /// <summary>
        /// Get the system address street prefixes
        /// </summary>
        /// <param name="request">The request</param>
        /// <returns>Return all street prefixes</returns>
        public StreetPrefixesResponse GetStreetPrefixes(StreetPrefixesRequest request)
        {
            return ReferenceDataRepository.GetStreetPrefixes(request);
        }

        /// <summary>
        /// Gets the asset statuses.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>the asset statuses.</returns>
        public AssetStatusesResponse GetAssetStatuses(AssetStatusesRequest request)
        {
            return ReferenceDataRepository.GetAssetStatuses(request);
        }

        public AssetTypesResponse GetAssetTypes(AssetTypesRequest request)
        {
            return ReferenceDataRepository.GetAssetTypes(request);
        }

        /// <summary>
        /// Gets the asset unit types
        /// </summary>
        /// <param name="request">The request</param>
        /// <returns>the asset unit types</returns>
        public AssetUnitTypesResponse GetAssetUnitTypes(AssetUnitTypesRequest request)
        {
            return ReferenceDataRepository.GetAssetUnitTypes(request);
        }

        public StandardChoicesResponse GetStandardChoices(GetStandardChoicesRequest request)
        {
            return ReferenceDataRepository.GetStandardChoices(request);
        }        

        /// <summary>
        /// Gets the asset ASIs.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>the asset ASIs.</returns>
        public AdditionalResponse GetAssetASIs(AssetASIsRequest request)
        {
            AdditionalResponse result = new AdditionalResponse();

            var response = ReferenceDataRepository.GetAssetASIs(request);

            if (response != null)
            {
                result.Additionals = response.Additionals;
                ASISecurityBusinessEntity.RemoveASIInvisableItems(result.Additionals);
            }

            return result;
        }

        /// <summary>
        /// Gets the asset ASITs.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>the asset ASITs.</returns>
        public AdditionalTableResponse GetAssetASITs(AssetASITsRequest request)
        {
            AdditionalTableResponse result = new AdditionalTableResponse();

            var response = ReferenceDataRepository.GetAssetASITs(request);

            if (response != null)
            {
                result.AdditionalTables = response.AdditionalTables;
                ASISecurityBusinessEntity.RemoveASITInvisableItems(result.AdditionalTables);
            }

            return result;
        }

        public RecordPrioritiesResponse GetRecordPriorities(RecordPrioritiesRequest request)
        {
            return ReferenceDataRepository.GetRecordPriorities(request);
        }

        /// <summary>
        /// Gets the modules of agency.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>modules response</returns>
        public ModulesResponse GetModules(ModulesRequest request)
        {
            return ReferenceDataRepository.GetModules(request);
        }

        /// <summary>
        /// Gets the inspection groups.
        /// </summary>
        /// <param name="cloudUser">The cloud user.</param>
        /// <param name="departmentId">The department id.</param>
        /// <returns>the inspectors.</returns>
        public InspectionGroupResponse GetInspectoinGroups(InspectionGroupRequest request)
        {
            return ReferenceDataRepository.GetInspectionGroups(request);
        }

        /// <summary>
        /// Gets all system departments
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public SystemDepartmentsResponse GetDepartments(SystemDepartmentsRequest request)
        {
            var response = new SystemDepartmentsResponse();

            response = ReferenceDataRepository.GetSystemDepartments(request);

            return response;
        }


        /// <summary>
        /// Gets a department's all staffs.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public SystemDepartmentStaffsResponse GetDepartmentStaffs(SystemDepartmentStaffsRequest request)
        {
            var response = new SystemDepartmentStaffsResponse();

            response = ReferenceDataRepository.GetSystemDepartmentStaffs(request);

            return response;
        }



        /// <summary>
        /// Gets the Inspection Groups's all Inspection Types.
        /// </summary>
        public SystemInspectionTypeResponse GetSystemInspectionTypes(SystemInspectionTypeRequest request)
        {
            return ReferenceDataRepository.GetSystemInspectionTypes(request);
        }

        /// <summary>
        /// get all work order templates.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public WorkOrderTemplateResponse GetWorkOrderTemplates(WorkOrderTemplateRequest request)
        {
            return ReferenceDataRepository.GetWorkOrderTemplates(request);
        }

        public SystemContactTypesResponse GetContactTypes(SystemContactTypesRequest request)
        {
            return ReferenceDataRepository.GetContactTypes(request);
        }

        public AssetCATypesResponse GetAssetCATypes(GetAssetCATypesRequest request)
        {
            return ReferenceDataRepository.GetAssetCATypes(request);
        }
    }
}
