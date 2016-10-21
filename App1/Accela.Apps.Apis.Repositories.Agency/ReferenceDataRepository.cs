using System;
using System.Collections.Generic;
using System.Linq;
using Accela.Apps.Apis.Models.DomainModels.AdditionalModels;
using Accela.Apps.Apis.Models.DomainModels.AssetModels;
using Accela.Apps.Apis.Models.DomainModels.CommentModels;
using Accela.Apps.Apis.Models.DomainModels.ContactModels;
using Accela.Apps.Apis.Models.DomainModels.InspectionModels;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;
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
using Accela.Apps.Apis.Models.DTOs.Responses.StandardChoicesResponses;
using Accela.Apps.Apis.Repositories.Agency.GovXmlHelpers;
using Accela.Apps.Apis.Repositories.GovXmlHelpers;
using Accela.Apps.Apis.Repositories.GovXmlQueries;
using Accela.Apps.Apis.Repositories.Interfaces;
using Accela.Automation.GovXmlClient.Model;
using Accela.Apps.Shared;
using Accela.Apps.Shared.Contexts;

namespace Accela.Apps.Apis.Repositories.Agency
{
    /// <summary>
    /// Reference data repository class.
    /// </summary>
    public class ReferenceDataRepository : RepositoryBase, IReferenceDataRepository
    {
        public ReferenceDataRepository(IAgencyAppContext contextEntity)
            : base(contextEntity)
        {

        }

        private OwnerHelper _ownerHelper;
        private OwnerHelper OwnerHelper
        {
            get
            {
                if (_ownerHelper == null)
                {
                    _ownerHelper = new OwnerHelper(this.Environment.BizServerVersion);
                }
                return _ownerHelper;
            }
        }

        public InspectionTypeResponse GetInspetionTypes(InspectionTypeRequest request)
        {
            InspectionTypeResponse result = null;
            var entityList = ReferenceDataCache.Instance.GetInspetionTypes(this.CurrentContext);

            if (entityList == null || entityList.Count == 0)
            {
                QueryBase query = new QueryBase()
                {
                    RowStart = 0,
                    PageSize = 0
                };

                GovXML govXmlIn = new GovXML();
                govXmlIn.getInspectionTypes = new GetInspectionTypes();
                govXmlIn.getInspectionTypes.system = CommonHelper.GetSystem(request, this.CurrentContext);

                GovXML response = CommonHelper.Post(govXmlIn,
                                                    govXmlIn.getInspectionTypes.system,
                                                    (o) => o.getInspectionTypesResponse == null ? null : o.getInspectionTypesResponse.system);

                result = InspectionTypeHelper.ToClientInspectionTypes(response.getInspectionTypesResponse);

                if (result != null && result.InspectionTypes != null && result.InspectionTypes.Count > 0)
                {
                    ReferenceDataCache.Instance.CacheInspectionTypes(result.InspectionTypes, this.CurrentContext);
                }
            }
            else
            {
                result = new InspectionTypeResponse()
                {
                    InspectionTypes = entityList.ToList()
                };
            }

            return result;
        }

        public InspectionStatusResponse GetInspetionStatuses(InspectionStatusRequest request)
        {
            InspectionStatusResponse result = null;
            var inspectionTypes = this.GetInspetionTypes(new InspectionTypeRequest()
                                                             {
                                                                 Offset = 0,
                                                                 Limit = 0
                                                             });

            if (inspectionTypes != null && inspectionTypes.InspectionTypes != null && inspectionTypes.InspectionTypes.Count > 0)
            {
                var tempResult = from t in inspectionTypes.InspectionTypes
                                 where t != null
                                 && t.Identifier == request.InspectionTypeId
                                 && t.StatusList != null
                                 from s in t.StatusList
                                 where s != null
                                 select s;

                result = new InspectionStatusResponse()
                {
                    InspectionStatuses = tempResult.ToList()
                };
            }

            return result;
        }

        public StandardCommentGroupResponse GetStandardCommentGroups(StandardCommentGroupRequest request)
        {
            StandardCommentGroupResponse result = null;
            var entityList = ReferenceDataCache.Instance.GetStandardCommentGroups(this.CurrentContext);

            if (entityList == null || entityList.Count == 0)
            {
                QueryBase queryBase = new QueryBase()
                {
                    RowStart = 0,
                    PageSize = 0
                };

                GovXML govXmlIn = new GovXML();
                govXmlIn.getStandardComments = new GetStandardComments();
                govXmlIn.getStandardComments.system = CommonHelper.GetSystem(request, this.CurrentContext);

                GovXML response = CommonHelper.Post(govXmlIn,
                                                    govXmlIn.getStandardComments.system,
                                                    (o) => o.getStandardCommentsResponse == null ? null : o.getStandardCommentsResponse.system);

                StandardCommentResponse allComments = StandardCommentHelper.ToClientStandardComments(response.getStandardCommentsResponse);

                var tempGroupResult = allComments == null || allComments.StandardComments == null ? null :
                    from c in allComments.StandardComments
                    where c != null
                    && c.CommentGroup != null
                    group c.CommentGroup by c.CommentGroup.Identifier into commentGroup
                    select commentGroup.First();
                entityList = tempGroupResult.ToList();

                if (allComments != null && allComments.StandardComments != null && allComments.StandardComments.Count > 0)
                {
                    ReferenceDataCache.Instance.CacheStandardCommentRelatedData(allComments.StandardComments, this.CurrentContext);
                }
            }

            // We should return a response no matter how many groups we found, even if there is no group foun
            if (entityList != null)
            {
                result = new StandardCommentGroupResponse()
                {
                    StandardCommentGroups = entityList.ToList()
                };
            }

            return result;
        }

        public DepartmentResponse GetDepartments(DepartmentRequest request)
        {
            DepartmentResponse result = null;
            var entityList = ReferenceDataCache.Instance.GetDepartments(this.CurrentContext);

            if (entityList == null || entityList.Count == 0)
            {
                QueryBase queryBase = new QueryBase()
                {
                    RowStart = 0,
                    PageSize = 0
                };

                var system = CommonHelper.GetSystem(request, this.CurrentContext);

                var getDepartments = new GetDepartments();
                getDepartments.system = system;
                var govXml4GetDepartments = new GovXML();
                govXml4GetDepartments.getDepartments = getDepartments;
                GovXML departmentResponse = CommonHelper.Post(govXml4GetDepartments,
                                                              system,
                                                              (o) => o.getDepartmentsResponse == null ? null : o.getDepartmentsResponse.system);

                var getInspectors = new GetInspectors();
                getInspectors.system = system;
                var govXml4GetInspectors = new GovXML();
                govXml4GetInspectors.getInspectors = getInspectors;
                GovXML inspectorResponse = CommonHelper.Post(govXml4GetInspectors,
                                                             system,
                                                             (o) => o.getInspectorsResponse == null ? null : o.getInspectorsResponse.system);

                result = InspectorHelper.ToClientDepartmentWithInspector(departmentResponse.getDepartmentsResponse, inspectorResponse.getInspectorsResponse);

                if (result != null && result.Departments != null && result.Departments.Count > 0)
                {
                    ReferenceDataCache.Instance.CacheDepartments(result.Departments, this.CurrentContext);
                }
            }
            else
            {
                result = new DepartmentResponse()
                {
                    Departments = entityList.ToList()
                };
            }

            if (request != null && !string.IsNullOrWhiteSpace(request.InspectorId) && result != null && result.Departments != null)
            {
                DepartmentModel selectedDep = null;
                foreach (var dep in result.Departments)
                {
                    if (dep != null && dep.Inspectors != null)
                    {
                        foreach (var inspector in dep.Inspectors)
                        {
                            if (inspector != null && inspector.Identifier == request.InspectorId)
                            {
                                selectedDep = dep;
                                break;
                            }
                        }

                        if (selectedDep != null)
                            break;
                    }
                }

                result.Departments = new List<DepartmentModel>();
                result.Departments.Add(selectedDep);

            }

            return result;
        }

        public InspectorResponse GetInspectors(InspectorRequest request)
        {
            InspectorResponse result = null;
            var departments = GetDepartments(new DepartmentRequest());

            if (departments != null && departments.Departments != null && departments.Departments.Count > 0)
            {
                var tempResult = from d in departments.Departments
                                 where d != null
                                 && d.Identifier == request.DepartmentId
                                 && d.Inspectors != null
                                 from i in d.Inspectors
                                 where i != null
                                 select i;
                result = new InspectorResponse()
                {
                    Inspectors = tempResult.ToList()
                };
            }

            return result;
        }

        public StandardCommentResponse GetStandardComments(StandardCommentRequest request)
        {
            StandardCommentResponse result = null;
            var entityList = ReferenceDataCache.Instance.GetStandardComments(this.CurrentContext) as List<StandardCommentModel>;

            if (entityList == null || entityList.Count == 0)
            {
                QueryBase queryBase = new QueryBase()
                {
                    RowStart = 0,
                    PageSize = 0
                };

                result = GetStandardCommentsNoCache(request);

                if (result.StandardComments != null && result.StandardComments.Count > 0)
                {
                    ReferenceDataCache.Instance.CacheStandardCommentRelatedData(result.StandardComments, this.CurrentContext);
                }
            }
            else
            {
                result = new StandardCommentResponse()
                {
                    StandardComments = entityList
                };
            }

            if (result.StandardComments != null)
            {
                if (request.Groups != null)
                {
                    result.StandardComments = result.StandardComments.FindAll(comment => request.Groups.Contains(comment.CommentGroup.Identifier)).ToPagedList(request);
                }
                else
                {
                    result.StandardComments = result.StandardComments.ToPagedList(request);
                }
            }

            var totalCount = result.StandardComments != null ? result.StandardComments.Count : 0;

            result.PageInfo = CommonHelper.GetPaginationFromResult(request, result.StandardComments, totalCount);

            return result;
        }


        public StandardCommentResponse GetStandardCommentsNoCache(StandardCommentRequest request)
        {
            GovXML govXmlIn = new GovXML();
            govXmlIn.getStandardComments = new GetStandardComments();
            govXmlIn.getStandardComments.system = CommonHelper.GetSystem(request, this.CurrentContext);

            GovXML response = CommonHelper.Post(govXmlIn,
                                                govXmlIn.getStandardComments.system,
                                                (o) => o.getStandardCommentsResponse == null ? null : o.getStandardCommentsResponse.system);

            StandardCommentResponse results = StandardCommentHelper.ToClientStandardComments(response.getStandardCommentsResponse);
            results.PageInfo = CommonHelper.GetPaginationFromSystem(response.getStandardCommentsResponse.system);

            return results;
        }

        public InspectionTypeResponse GetInspetionTypesNoCache(InspectionTypeRequest request)
        {
            GovXML govXmlIn = new GovXML();

            govXmlIn.getInspectionTypes = new GetInspectionTypes();
            govXmlIn.getInspectionTypes.system = CommonHelper.GetSystem(request, this.CurrentContext);

            GovXML response = CommonHelper.Post(govXmlIn, govXmlIn.getInspectionTypes.system,
                                                (o) =>
                                                o.getInspectionTypesResponse == null
                                                    ? null
                                                    : o.getInspectionTypesResponse.system);

            InspectionTypeResponse results = InspectionTypeHelper.ToClientInspectionTypes(response.getInspectionTypesResponse);
            results.PageInfo = CommonHelper.GetPaginationFromSystem(response.getInspectionTypesResponse.system);

            return results;
        }

        public AdditionalResponse GetAdditionals(AdditionalRequest request)
        {
            GovXML govXmlIn = new GovXML();
            govXmlIn.GetAdditionalInformationGroups = new GetAdditionalInformationGroups();
            govXmlIn.GetAdditionalInformationGroups.system = CommonHelper.GetSystem(request, this.CurrentContext);

            GovXML response = CommonHelper.Post(govXmlIn,
                                                govXmlIn.GetAdditionalInformationGroups.system,
                                                (o) => o.GetAdditionalInformationGroupsResponse == null ? null : o.GetAdditionalInformationGroupsResponse.system);

            AdditionalResponse results = ASIHelper.GetClientAdditionals(response.GetAdditionalInformationGroupsResponse);
            results.PageInfo = CommonHelper.GetPaginationFromSystem(response.GetAdditionalInformationGroupsResponse.system);

            return results;
        }

        public OwnersResponse GetOwners(OwnersRequest request)
        {
            GovXML govXmlIn = new GovXML();
            var getOwners = new GetOwners();
            getOwners.system = CommonHelper.GetSystem(request, this.CurrentContext);
            govXmlIn.getOwners = getOwners;
            List<OwnerModel> ownerList = null;

            if (request.OwnerWithNoId != null)
            {
                ownerList = new List<OwnerModel>();
                ownerList.Add(request.OwnerWithNoId);
            }

            getOwners.contacts = OwnerHelper.ToXMLQueryContacts(ownerList);
            getOwners.GisObjects = OwnerHelper.ToXMLQueryGISObjects(request.GisObjects);

            GovXML response = CommonHelper.Post(govXmlIn,
                                                getOwners.system,
                                                (o) => o.getOwnersResponse == null ? null : o.getOwnersResponse.system);

            OwnersResponse result = OwnerHelper.ToClientOwners(response.getOwnersResponse);

            return result;
        }

        public RecordTypesResponse GetRecordTypes(RecordTypesRequest request)
        {
            RecordTypesResponse result = null;

            if (request == null)
            {
                return null;
            }

            var entityList = ReferenceDataCache.Instance.GetRecordTypes(request.Module, this.CurrentContext);

            if (entityList == null || entityList.Count == 0)
            {
                var newRequest = new RecordTypesRequest()
                {
                    Offset = 0,
                    Limit = 0,
                };

                newRequest.Module = request.Module;

                var govXmlIn = new GovXML
                {
                    getCAPTypes =
                        new GetCAPTypes {system = CommonHelper.GetSystem(newRequest, this.CurrentContext), Module = newRequest.Module}
                };

                var response = CommonHelper.Post(govXmlIn,
                                                    govXmlIn.getCAPTypes.system,
                                                    (o) => o.getCAPTypesResponse == null ? null : o.getCAPTypesResponse.system);

                result = RecordTypeHelper.ToClientRecordTypes(response.getCAPTypesResponse);

                if (result.RecordTypes != null && result.RecordTypes.Count > 0)
                {
                    var cacheData = new List<RecordTypeModel>(result.RecordTypes.ToArray());
                    ReferenceDataCache.Instance.CacheRecordTypes(cacheData, request.Module, this.CurrentContext);
                }
            }
            else
            {
                result = new RecordTypesResponse()
                {
                    RecordTypes = entityList.ToList()
                };
            }

            if (result.RecordTypes != null && result.RecordTypes.Count > 0 && !string.IsNullOrEmpty(request.RecordTypeId))
            {
                result.RecordTypes = result.RecordTypes.Where(rt => rt.Identifier == request.RecordTypeId).ToList();
            }

            var totalCount = result.RecordTypes != null ? result.RecordTypes.Count : 0;

            if (result.RecordTypes != null)
            {
                result.RecordTypes = result.RecordTypes.ToPagedList(request);
            }

            result.PageInfo = CommonHelper.GetPaginationFromResult(request, result.RecordTypes, totalCount);

            return result;
        }

        public AdditionalGroupResponse GetAdditionalGroups(AdditionalGroupRequest request)
        {
            AdditionalGroupResponse result = null;

            if (request == null)
            {
                return result;
            }

            var entityList = ReferenceDataCache.Instance.GetAdditionalGroups(this.CurrentContext);

            if (entityList == null || entityList.Count == 0)
            {
                GovXML govXmlIn = new GovXML();
                govXmlIn.GetAdditionalInformationGroups = new GetAdditionalInformationGroups();
                govXmlIn.GetAdditionalInformationGroups.system = CommonHelper.GetSystem(request, this.CurrentContext);

                GovXML response = CommonHelper.Post(govXmlIn,
                                                    govXmlIn.GetAdditionalInformationGroups.system,
                                                    (o) => o.GetAdditionalInformationGroupsResponse == null ? null : o.GetAdditionalInformationGroupsResponse.system);

                result = RecordTypeHelper.ToClientAdditionalGroups(response.GetAdditionalInformationGroupsResponse);

                if (result.AdditionalGroups != null && result.AdditionalGroups.Count > 0)
                {
                    ReferenceDataCache.Instance.CacheAdditionalGroups(result.AdditionalGroups, this.CurrentContext);
                }
            }
            else
            {
                result = new AdditionalGroupResponse()
                {
                    AdditionalGroups = entityList.ToList()
                };
            }

            return result;
        }

        public SystemInspectorResponse GetSystemInspectors(SystemInspectorRequest request)
        {
            if (request == null)
            {
                return null;
            }

            IList<SystemInspectorModel> systemInspectorModels = ReferenceDataCache.Instance.GetInspectors(this.CurrentContext);

            if (systemInspectorModels == null || systemInspectorModels.Count == 0)
            {
                var newRequest = new SystemInspectorRequest()
                {
                    Offset = 0,
                    Limit = 0,
                };

                GovXML govXmlIn = new GovXML();
                govXmlIn.getInspectors = new GetInspectors();
                govXmlIn.getInspectors.system = CommonHelper.GetSystem(newRequest, this.CurrentContext);

                GovXML response = CommonHelper.Post(govXmlIn,
                                                    govXmlIn.getInspectors.system,
                                                    (o) => o.getInspectorsResponse == null ? null : o.getInspectorsResponse.system);

                systemInspectorModels = SystemInspectorHelper.ToClientInspectors(response.getInspectorsResponse);

                if (systemInspectorModels.Count > 0)
                {
                    ReferenceDataCache.Instance.CacheSystemInspectors(systemInspectorModels, this.CurrentContext);
                }
            }

            IList<SystemInspectorModel> allInspector = systemInspectorModels ?? new List<SystemInspectorModel>();

            var result = new SystemInspectorResponse();
            result.Inspectors = allInspector.ToPagedList(request);
            result.PageInfo = CommonHelper.GetPaginationFromResult(request, result.Inspectors, allInspector.Count);
            return result;
        }

        public DocumentTypesResponse GetDocumentTypes(DocumentTypeRequest request)
        {
            GovXML govXmlIn = new GovXML();
            govXmlIn.getDocumentGroups = new GetDocumentGroups();
            govXmlIn.getDocumentGroups.system = CommonHelper.GetSystem(request, this.CurrentContext);

            GovXML response = CommonHelper.Post(govXmlIn,
                                                govXmlIn.getDocumentGroups.system,
                                                (o) => o.getDocumentGroupsResponse == null ? null : o.getDocumentGroupsResponse.system);

            DocumentTypesResponse results = AttachmentHelper.ToClientDocumentType(response.getDocumentGroupsResponse);

            return results;
        }

        public StreetPrefixesResponse GetStreetPrefixes(StreetPrefixesRequest request)
        {
            GovXML govXmlIn = new GovXML();
            govXmlIn.GetStreetDirections = new GetStreetDirections();
            govXmlIn.GetStreetDirections.system = CommonHelper.GetSystem(request, this.CurrentContext);

            GovXML response = CommonHelper.Post(govXmlIn,
                                                govXmlIn.GetStreetDirections.system,
                                                (o) => o.GetStreetDirectionsResponse == null ? null : o.GetStreetDirectionsResponse.system);

            var results = StreetPrefixHelper.GetClientStreetPrefixes(response.GetStreetDirectionsResponse);

            return results;
        }

        public AssetStatusesResponse GetAssetStatuses(AssetStatusesRequest request)
        {
            GovXML govXmlIn = new GovXML();
            govXmlIn.getDispositions = new GetDispositions();
            govXmlIn.getDispositions.system = CommonHelper.GetSystem(request, this.CurrentContext);
            govXmlIn.getDispositions.contextType = "AssetStatus";

            GovXML response = CommonHelper.Post(govXmlIn,
                govXmlIn.getDispositions.system,
                (o) => o.getDispositionsResponse == null ? null : o.getDispositionsResponse.system);

            var results = AssetHelper.GetClientAssetStatuses(response.getDispositionsResponse);

            return results;
        }

        public AssetTypesResponse GetAssetTypes(AssetTypesRequest request)
        {
            List<AssetTypeModel> entityList = ReferenceDataCache.Instance.GetAssetTypes(this.CurrentContext);

            if (entityList == null || entityList.Count == 0)
            {
                var newRequest = new AssetTypesRequest()
                {
                    Offset = 0,
                    Limit = 0
                };

                GovXML govXmlIn = new GovXML();
                govXmlIn.getAssetTypes = new GetAssetTypes();
                govXmlIn.getAssetTypes.system = CommonHelper.GetSystem(newRequest, this.CurrentContext);

                GovXML response = CommonHelper.Post(govXmlIn,
                                                    govXmlIn.getAssetTypes.system,
                                                    (o) => o.getAssetTypesResponse == null ? null : o.getAssetTypesResponse.system);

                var assetTypes = AssetHelper.GetClientAssetTypes(response.getAssetTypesResponse);

                if (assetTypes != null && assetTypes.Types != null)
                {
                    entityList = assetTypes.Types;
                    ReferenceDataCache.Instance.CacheAssetTypes(assetTypes.Types, this.CurrentContext);
                }
            }

            var totalCount = entityList != null ? entityList.Count : 0;

            if (entityList != null)
            {
                entityList = entityList.ToPagedList(request);
            }

            AssetTypesResponse retu = new AssetTypesResponse();
            retu.PageInfo = CommonHelper.GetPaginationFromResult(request, entityList, totalCount);
            retu.Types = entityList;
            return retu;
        }

        public AssetUnitTypesResponse GetAssetUnitTypes(AssetUnitTypesRequest request)
        {
            GovXML govXmlIn = new GovXML();
            govXmlIn.getStandardChoices = new GetStandardChoices();
            govXmlIn.getStandardChoices.system = CommonHelper.GetSystem(request, this.CurrentContext);
            govXmlIn.getStandardChoices.standardChoiceType = "ASSET_SIZE_UNIT";

            GovXML response = CommonHelper.Post(govXmlIn,
                govXmlIn.getStandardChoices.system,
                (o) => o.getStandardChoicesResponse == null ? null : o.getStandardChoicesResponse.system);

            var results = AssetHelper.GetAssetUnitTypes(response.getStandardChoicesResponse);

            return results;
        }

        public StandardChoicesResponse GetStandardChoices(GetStandardChoicesRequest request)
        {
            GovXML govXmlIn = new GovXML();
            govXmlIn.getStandardChoices = new GetStandardChoices();
            govXmlIn.getStandardChoices.system = CommonHelper.GetSystem(request, this.CurrentContext);
            govXmlIn.getStandardChoices.standardChoiceType = request.StandardChoiceType;
            govXmlIn.getStandardChoices.standardChoiceItem = request.StandardChoiceValue;

            GovXML response = CommonHelper.Post(govXmlIn,
                govXmlIn.getStandardChoices.system,
                (o) => o.getStandardChoicesResponse == null ? null : o.getStandardChoicesResponse.system);

            var results = StandardChoicesHelper.GetStandardChoices(response.getStandardChoicesResponse);

            return results;
        }

        public AssetCATypesResponse GetAssetCATypes(GetAssetCATypesRequest request)
        {
            List<AssetCATypeModel> entityList = ReferenceDataCache.Instance.GetAssetCATypes(this.CurrentContext);

            if (entityList == null || entityList.Count == 0)
            {
                var newRequest = new GetAssetCATypesRequest()
                {
                    Offset = 0,
                    Limit = 0
                };

                GovXML govXmlIn = new GovXML();
                govXmlIn.GetAssetCATypes = new GetAssetCATypes();
                govXmlIn.GetAssetCATypes.system = CommonHelper.GetSystem(request, this.CurrentContext);
                GovXML response = CommonHelper.Post(govXmlIn,
                govXmlIn.GetAssetCATypes.system,
                (o) => o.GetAssetCATypesResponse == null ? null : o.GetAssetCATypesResponse.system); ;

                var assetCATypes = AssetHelper.GetAssetCATypes(response.GetAssetCATypesResponse);

                if (assetCATypes != null && assetCATypes.AssetCATypes != null)
                {
                    entityList = assetCATypes.AssetCATypes;
                    ReferenceDataCache.Instance.CachAssetCATypes(assetCATypes.AssetCATypes, this.CurrentContext);
                }
            }

            var totalCount = entityList != null ? entityList.Count : 0;

            if (entityList != null)
            {
                entityList = entityList.ToPagedList(request);
            }

            AssetCATypesResponse retu = new AssetCATypesResponse();
            retu.AssetCATypes = entityList;
            return retu;
        }

        public AdditionalResponse GetAssetASIs(AssetASIsRequest request)
        {
            AdditionalResponse result = null;
            var asiAsitRequest = new AdditionalGroupRequest();
            var asiAsits = GetAssetASIAndASITs(asiAsitRequest);

            if (asiAsits != null && asiAsits.AdditionalGroups != null)
            {
                var tempResults = (from g in asiAsits.AdditionalGroups
                                   where g != null
                                   && g.SubGroups != null
                                   from s in g.SubGroups
                                   where s != null
                                   && !String.IsNullOrWhiteSpace(s.Display)
                                   && s.Display.Equals(g.Display)
                                   select g).ToList();


                var totalCount = tempResults.Count;

                if (totalCount > 0)
                {
                    tempResults = tempResults.ToPagedList(request);

                    result = new AdditionalResponse()
                    {
                        Additionals = tempResults
                    };

                    result.PageInfo = CommonHelper.GetPaginationFromResult(request, result.Additionals, totalCount);
                }
            }

            return result;
        }

        public AdditionalTableResponse GetAssetASITs(AssetASITsRequest request)
        {
            AdditionalTableResponse result = null;
            var asiAsitRequest = new AdditionalGroupRequest();
            var asiAsits = GetAssetASIAndASITs(asiAsitRequest);

            if (asiAsits != null && asiAsits.AdditionalGroups != null)
            {
                var tempResults = (from g in asiAsits.AdditionalGroups
                                   where g != null
                                   && g.SubGroups != null
                                   from s in g.SubGroups
                                   where s != null
                                   && !String.IsNullOrWhiteSpace(s.Display)
                                   && !s.Display.Equals(g.Display)
                                   select g).ToList();


                var totalCount = tempResults.Count;

                if (totalCount > 0)
                {
                    tempResults = tempResults.ToPagedList(request);
                    result = new AdditionalTableResponse()
                    {
                        AdditionalTables = new List<AdditionalTableModel>()
                    };

                    foreach (var group in tempResults)
                    {
                        result.AdditionalTables.AddRange(GetAdditionalTableByGroup(group));
                    }

                    result.PageInfo = CommonHelper.GetPaginationFromResult(request, result.AdditionalTables, totalCount);
                }
            }

            return result;
        }

        private List<AdditionalTableModel> GetAdditionalTableByGroup(AdditionalGroupModel request)
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
                    table.Columns = new List<AdditionalColumnModel>();
                    if (subGroup.Items != null && subGroup.Items.Count > 0)
                    {
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
                            table.Columns.Add(column);
                        }
                    }

                    results.Add(table);
                }
            }

            return results;
        }

        private AdditionalGroupResponse GetAssetASIAndASITs(AdditionalGroupRequest request)
        {
            AdditionalGroupResponse result = null;

            if (request == null)
            {
                return result;
            }

            var entityList = ReferenceDataCache.Instance.GetAssetASIAndASITs(this.CurrentContext);

            if (entityList == null || entityList.Count == 0)
            {
                var newRequest = new AdditionalGroupRequest()
                {
                    Offset = 0,
                    Limit = 0
                };

                GovXML govXmlIn = new GovXML();
                govXmlIn.GetAdditionalInformationGroups = new GetAdditionalInformationGroups();
                govXmlIn.GetAdditionalInformationGroups.system = CommonHelper.GetSystem(request, this.CurrentContext);
                govXmlIn.GetAdditionalInformationGroups.contextType = "Asset";

                GovXML response = CommonHelper.Post(govXmlIn,
                                                    govXmlIn.GetAdditionalInformationGroups.system,
                                                    (o) => o.GetAdditionalInformationGroupsResponse == null ? null : o.GetAdditionalInformationGroupsResponse.system);

                AdditionalGroupResponse asiAndASITs = AssetHelper.ToClientAdditionalGroups(response.GetAdditionalInformationGroupsResponse);

                if (asiAndASITs != null && asiAndASITs.AdditionalGroups != null && asiAndASITs.AdditionalGroups.Count > 0)
                {
                    var cacheData = new List<AdditionalGroupModel>(asiAndASITs.AdditionalGroups.ToArray());
                    entityList = new List<AdditionalGroupModel>(asiAndASITs.AdditionalGroups.ToArray());
                    ReferenceDataCache.Instance.CacheAssetASIAndASITs(cacheData, this.CurrentContext);
                }
            }

            if (entityList != null && entityList.Count > 0)
            {
                result = new AdditionalGroupResponse()
                {
                    AdditionalGroups = entityList.ToList()
                };
            }

            return result;
        }

        public RecordPrioritiesResponse GetRecordPriorities(RecordPrioritiesRequest request)
        {
            GovXML govXmlIn = new GovXML();
            govXmlIn.getStandardChoices = new GetStandardChoices();
            govXmlIn.getStandardChoices.system = CommonHelper.GetSystem(request, this.CurrentContext);
            govXmlIn.getStandardChoices.standardChoiceType = "PRIORITY";

            GovXML response = CommonHelper.Post(govXmlIn,
                                                govXmlIn.getStandardChoices.system,
                                                (o) => o.getStandardChoicesResponse == null ? null : o.getStandardChoicesResponse.system);

            RecordPrioritiesResponse result = RecordHelper.ToClientRecordPriorities(response.getStandardChoicesResponse);

            return result;
        }

        public ModulesResponse GetModules(ModulesRequest request)
        {
            GovXML govXmlIn = new GovXML();
            govXmlIn.getModules = new GetModules();
            govXmlIn.getModules.system = CommonHelper.GetSystem(request, this.CurrentContext);

            GovXML response = CommonHelper.Post(govXmlIn,
                                                govXmlIn.getModules.system,
                                                (o) => o.getModulesResponse == null ? null : o.getModulesResponse.system);

            ModulesResponse result = null;

            if (response != null
                && response.getModulesResponse != null
                && response.getModulesResponse.Modules != null
                && response.getModulesResponse.Modules.Module != null)
            {
                result = new ModulesResponse();
                result.Modules = response.getModulesResponse.Modules.Module.Select(m => new ModuleModel() { Key = m.Key, Value = m.Value }).ToList();
            }

            return result;
        }

        public InspectionGroupResponse GetInspectionGroups(InspectionGroupRequest request)
        {
            if (request == null)
            {
                return null;
            }

            IList<InspectionGroupModel> allInspectionGroup = GetAllInspectionGroupModels();

            var result = new InspectionGroupResponse();
            result.InspectionGroups = allInspectionGroup.ToPagedList(request);
            result.PageInfo = CommonHelper.GetPaginationFromResult(request, result.InspectionGroups, allInspectionGroup.Count);

            return result;
        }

        public SystemInspectionTypeResponse GetSystemInspectionTypes(SystemInspectionTypeRequest request)
        {
            if (request == null)
            {
                return null;
            }

            IList<InspectionGroupModel> inspectionGroupModels = GetAllInspectionGroupModels();

            var group = inspectionGroupModels.FirstOrDefault(x => x.Identifier.Equals(request.InspectionGroupId, StringComparison.InvariantCultureIgnoreCase));

            SystemInspectionTypeResponse result = new SystemInspectionTypeResponse();
            if (group != null)
            {
                result.Types = group.Types.ToPagedList(request);
                result.PageInfo = CommonHelper.GetPaginationFromResult(request, result.Types, group.Types.Count);
            }
            else
            {
                result.Types = new List<SystemInspectionTypeModel>();
                result.PageInfo = null;
            }

            return result;
        }

        private IList<InspectionGroupModel> GetAllInspectionGroupModels()
        {
            IList<InspectionGroupModel> inspectionGroupModels = ReferenceDataCache.Instance.GetInspectionGroups(this.CurrentContext);

            if (inspectionGroupModels == null || inspectionGroupModels.Count == 0)
            {
                GovXML govXmlIn = new GovXML();
                govXmlIn.getInspectionTypes = new GetInspectionTypes();
                govXmlIn.getInspectionTypes.system = CommonHelper.GetSystemFromPosition(0, 0, this.CurrentContext);

                GovXML response = CommonHelper.Post(govXmlIn,
                                                    govXmlIn.getInspectionTypes.system,
                                                    (o) => o.getInspectionTypesResponse == null ? null : o.getInspectionTypesResponse.system);

                inspectionGroupModels = InspectionTypeHelper.ToClientInspectionGroups(response.getInspectionTypesResponse);

                if (inspectionGroupModels.Count > 0)
                {
                    ReferenceDataCache.Instance.CacheInspectionGroups(inspectionGroupModels, this.CurrentContext);
                }
            }
            return inspectionGroupModels ?? new List<InspectionGroupModel>();
        }

        public SystemDepartmentsResponse GetSystemDepartments(SystemDepartmentsRequest request)
        {
            if (request == null)
            {
                return null;
            }
            IList<SystemDepartmentModel> allDepartment = GetAllSystemDepartments();
            var result = new SystemDepartmentsResponse();
            result.Departments = allDepartment.ToPagedList(request);
            result.PageInfo = CommonHelper.GetPaginationFromResult(request, result.Departments, allDepartment.Count);

            return result;
        }

        public SystemDepartmentStaffsResponse GetSystemDepartmentStaffs(SystemDepartmentStaffsRequest request)
        {
            if (request == null)
            {
                return null;
            }

            IList<SystemDepartmentModel> allDepartment = GetAllSystemDepartments();
            SystemDepartmentModel department = allDepartment.FirstOrDefault(
                    x => x.Id.Equals(request.DepartmentId, StringComparison.InvariantCultureIgnoreCase));

            var result = new SystemDepartmentStaffsResponse();
            if (department != null)
            {
                result.Staffs = department.Staffs.ToPagedList(request);
                if (department.Staffs != null)
                {
                    var totalRows = department.Staffs.Count();
                    result.PageInfo = CommonHelper.GetPaginationFromResult(request, result.Staffs, totalRows);
                }
            }
            else
            {
                result.Staffs = null;
                result.PageInfo = null;
            }

            return result;
        }

        private IList<SystemDepartmentModel> GetAllSystemDepartments()
        {
            IList<SystemDepartmentModel> systemDepartmentModels = ReferenceDataCache.Instance.GetAllSystemDepartments(this.CurrentContext);
            if (systemDepartmentModels == null || systemDepartmentModels.Count == 0)
            {
                GovXML govXmlIn = new GovXML();
                govXmlIn.getDepartments = new GetDepartments();
                govXmlIn.getDepartments.system = CommonHelper.GetSystemFromPosition(0, 0, this.CurrentContext);

                GovXML response = CommonHelper.Post(govXmlIn,
                                                    govXmlIn.getDepartments.system,
                                                    (o) => o.getDepartmentsResponse == null ? null : o.getDepartmentsResponse.system);

                systemDepartmentModels = DepartmentHelper.ToClientDepartments(response.getDepartmentsResponse);

                if (systemDepartmentModels.Count > 0)
                {
                    ReferenceDataCache.Instance.CacheSystemDepartments(systemDepartmentModels, this.CurrentContext);
                }
            }
            return systemDepartmentModels ?? new List<SystemDepartmentModel>();
        }

        public WorkOrderTemplateResponse GetWorkOrderTemplates(WorkOrderTemplateRequest request)
        {
            IList<WorkOrderTemplateModel> allWorkOrderTemplates = ReferenceDataCache.Instance.GetTemplates(SystemWorkOrderHelpler.WORK_ORDER_TYPPS_MODULE_NAME, this.CurrentContext);

            if (allWorkOrderTemplates == null || allWorkOrderTemplates.Count == 0)
            {
                WorkOrderTemplateRequest newRequest = new WorkOrderTemplateRequest
                {
                    Offset = 0,
                    Limit = 0
                };

                GovXML govXmlIn = new GovXML();
                govXmlIn.getWorkOrderTemplates = new GetWorkOrderTemplates();
                //govXmlIn.getWorkOrderTemplates.contextType = "";
                govXmlIn.getWorkOrderTemplates.system = CommonHelper.GetSystem(newRequest, this.CurrentContext);

                GovXML response = CommonHelper.Post(govXmlIn, govXmlIn.getWorkOrderTemplates.system,
                                                    (o) =>
                                                     o.getWorkOrderTemplatesResponse == null ? null : o.getWorkOrderTemplatesResponse.system);

                allWorkOrderTemplates = SystemWorkOrderHelpler.ToClientWorkOrderTemplates(response.getWorkOrderTemplatesResponse);

                if (allWorkOrderTemplates.Count > 0)
                {
                    ReferenceDataCache.Instance.CacheTemplates(allWorkOrderTemplates, SystemWorkOrderHelpler.WORK_ORDER_TYPPS_MODULE_NAME, this.CurrentContext);
                }
            }

            WorkOrderTemplateResponse result = new WorkOrderTemplateResponse();
            result.Templates = allWorkOrderTemplates.ToPagedList(request);
            result.PageInfo = CommonHelper.GetPaginationFromResult(request, result.Templates, allWorkOrderTemplates.Count);

            return result;
        }

        public SystemContactTypesResponse GetContactTypes(SystemContactTypesRequest request)
        {
            if (request == null)
            {
                return null;
            }

            IList<ContactRoleModel> allContactTypes = GetAllContactTypes();

            SystemContactTypesResponse result = new SystemContactTypesResponse();

            result.Types = allContactTypes.ToPagedList(request);

            result.PageInfo = CommonHelper.GetPaginationFromResult(request, result.Types, allContactTypes.Count);

            return result;
        }

        private IList<ContactRoleModel> GetAllContactTypes()
        {
            IList<ContactRoleModel> cacheContactTypes = ReferenceDataCache.Instance.GetSystemContactTypes(this.CurrentContext);

            if (cacheContactTypes == null || cacheContactTypes.Count == 0)
            {
                GovXML govXmlIn = new GovXML();
                govXmlIn.getRoles = new GetRoles();
                govXmlIn.getRoles.system = CommonHelper.GetSystemFromPosition(0, 0, this.CurrentContext);

                GovXML response = CommonHelper.Post(govXmlIn,
                                                    govXmlIn.getRoles.system,
                                                    (o) => o.getRolesResponse == null ? null : o.getRolesResponse.system);

                cacheContactTypes = ContactHelper.GetClientContactTypes(response.getRolesResponse);

                if (cacheContactTypes.Count > 0)
                {
                    ReferenceDataCache.Instance.CacheSystemContactTypes(cacheContactTypes, this.CurrentContext);
                }
            }

            return cacheContactTypes ?? new List<ContactRoleModel>();
        }

        public RecordStatusesResponse GetRecordDispositions(RecordStatusesRequest request)
        {
            GovXML govXmlIn = new GovXML();
            govXmlIn.getDispositions = new GetDispositions();
            govXmlIn.getDispositions.system = CommonHelper.GetSystem(request, this.CurrentContext);
            govXmlIn.getDispositions.contextType = "CAP";

            GovXML response = CommonHelper.Post(govXmlIn,
                govXmlIn.getDispositions.system,
                (o) => o.getDispositionsResponse == null ? null : o.getDispositionsResponse.system);

            RecordStatusesResponse results = RecordHelper.ToClientRecordDispositions(response.getDispositionsResponse);

            return results;
        }
    }
}
