
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
using Accela.Apps.Apis.Repositories.CitizenHelpers;
using Accela.Apps.Apis.Repositories.Interfaces;
using Accela.Automation.CitizenServices.Client.Models.Response.Record;
using Accela.Apps.Apis.Models.DTOs.Responses.StandardChoicesResponses;
using Accela.Apps.Shared;
using Accela.Apps.Shared.Contexts;
using Accela.Apps.Shared.Gateway.Client;
using Accela.Apps.Shared.Contants;
namespace Accela.Apps.Apis.Repositories.Citizen
{
    public class ReferenceDataRepository : RepositoryBase, IReferenceDataRepository
    {
        private IGatewayClient _gatewayClient;
        //private RestClient _restClient;
        //private RestClient RestClient
        //{
        //    get
        //    {
        //        if (_restClient == null)
        //        {
        //            _restClient = new RestClient(this.CurrentContext.Agency, this.CurrentContext.EnvName);
        //        }

        //        return _restClient;
        //    }
        //}

        //public ReferenceDataRepository(string appId, string agencyName, string serviceProvCode, string agencyUserId, string agencyUsername, string token, string environmentName, string language)
        //    : base(appId, agencyName, serviceProvCode, agencyUserId, agencyUsername, token, environmentName, language)
        //{

        //}
        public ReferenceDataRepository(IAgencyAppContext contextEntity, IGatewayClient gatewayClient)
            : base(contextEntity)
        {
            _gatewayClient = gatewayClient;
        }

        public InspectionTypeResponse GetInspetionTypes(InspectionTypeRequest request)
        {
            throw new System.NotImplementedException();
        }

        public InspectionStatusResponse GetInspetionStatuses(InspectionStatusRequest request)
        {
            throw new System.NotImplementedException();
        }

        public StandardCommentGroupResponse GetStandardCommentGroups(StandardCommentGroupRequest request)
        {
            throw new System.NotImplementedException();
        }

        public StandardCommentResponse GetStandardComments(StandardCommentRequest request)
        {
            throw new System.NotImplementedException();
        }

        public DepartmentResponse GetDepartments(DepartmentRequest request)
        {
            throw new System.NotImplementedException();
        }

        public InspectorResponse GetInspectors(InspectorRequest request)
        {
            throw new System.NotImplementedException();
        }

        public StandardCommentResponse GetStandardCommentsNoCache(StandardCommentRequest request)
        {
            throw new System.NotImplementedException();
        }

        public InspectionTypeResponse GetInspetionTypesNoCache(InspectionTypeRequest request)
        {
            throw new System.NotImplementedException();
        }

        public AdditionalResponse GetAdditionals(AdditionalRequest request)
        {
            throw new System.NotImplementedException();
        }

        public OwnersResponse GetOwners(OwnersRequest request)
        {
            throw new System.NotImplementedException();
        }

        public RecordTypesResponse GetRecordTypes(RecordTypesRequest recordTypeRequest)
        {
            var citizenRecordTypeRequest = CitizenRecordTypeHelper.GetCitizenRecordTypeRequest(recordTypeRequest);
            var module = citizenRecordTypeRequest.module;
            var token = this.CurrentContext.SocialToken;
            string requestUrl = string.Format("/rest/recordTypes?module={0}&token={1}", module, token);

            var citizenRecordTypesResponse = _gatewayClient.Get<CitizenGetRecordTypeResponse>(ApiTypes.LiteServiceWithRestPrefix,requestUrl);

            var recordTypeResponse = CitizenRecordTypeHelper.GetRecordTypesModel(citizenRecordTypesResponse);
            return recordTypeResponse;
        }

        public DocumentTypesResponse GetDocumentTypes(DocumentTypeRequest request)
        {
            throw new System.NotImplementedException();
        }

        public AdditionalGroupResponse GetAdditionalGroups(AdditionalGroupRequest request)
        {
            throw new System.NotImplementedException();
        }

        public StreetPrefixesResponse GetStreetPrefixes(StreetPrefixesRequest request)
        {
            throw new System.NotImplementedException();
        }

        public AssetStatusesResponse GetAssetStatuses(AssetStatusesRequest request)
        {
            throw new System.NotImplementedException();
        }

        public AssetTypesResponse GetAssetTypes(AssetTypesRequest request)
        {
            throw new System.NotImplementedException();
        }

        public AssetUnitTypesResponse GetAssetUnitTypes(AssetUnitTypesRequest request)
        {
            throw new System.NotImplementedException();
        }

        public AdditionalResponse GetAssetASIs(AssetASIsRequest request)
        {
            throw new System.NotImplementedException();
        }

        public AdditionalTableResponse GetAssetASITs(AssetASITsRequest request)
        {
            throw new System.NotImplementedException();
        }

        public RecordPrioritiesResponse GetRecordPriorities(RecordPrioritiesRequest request)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Gets the modules of agency.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>modules response</returns>
        public ModulesResponse GetModules(ModulesRequest request)
        {
            throw new System.NotImplementedException();
        }

        public SystemInspectorResponse GetSystemInspectors(SystemInspectorRequest request)
        {
            throw new System.NotImplementedException();
        }

        public SystemDepartmentsResponse GetSystemDepartments(SystemDepartmentsRequest request)
        {
            throw new System.NotImplementedException();
        }

        public SystemDepartmentStaffsResponse GetSystemDepartmentStaffs(SystemDepartmentStaffsRequest request)
        {
            throw new System.NotImplementedException();
        }

        public InspectionGroupResponse GetInspectionGroups(InspectionGroupRequest request)
        {
            throw new System.NotImplementedException();
        }



        public SystemInspectionTypeResponse GetSystemInspectionTypes(SystemInspectionTypeRequest request)
        {
            throw new System.NotImplementedException();
        }



        public WorkOrderTemplateResponse GetWorkOrderTemplates(WorkOrderTemplateRequest request)
        {
            throw new System.NotImplementedException();
        }


        public SystemContactTypesResponse GetContactTypes(SystemContactTypesRequest request)
        {
            throw new System.NotImplementedException();
        }

        public RecordStatusesResponse GetRecordDispositions(RecordStatusesRequest request)
        {
            throw new System.NotImplementedException();
        }


        public AssetCATypesResponse GetAssetCATypes(GetAssetCATypesRequest request)
        {
            throw new System.NotImplementedException();
        }


        public StandardChoicesResponse GetStandardChoices(GetStandardChoicesRequest request)
        {
            throw new System.NotImplementedException();
        }

        public StandardChoicesResponse GetI18NLanguageSettings(GetStandardChoicesRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}
