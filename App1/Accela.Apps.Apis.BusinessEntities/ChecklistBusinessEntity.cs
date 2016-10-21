using System.Collections.Generic;
using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Models.DTOs;
using Accela.Apps.Apis.Models.DTOs.Requests.ChecklistRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.ChecklistResponses;
using Accela.Apps.Apis.Repositories.Interfaces;
using Accela.Apps.Shared;
using Accela.Apps.Shared.Contexts;

namespace Accela.Apps.Apis.BusinessEntities
{
    public class ChecklistBusinessEntity : BusinessEntityBase, IChecklistBusinessEntity
    {
        
        public ChecklistBusinessEntity(IAgencyAppContext contextEntity, IChecklistRepository checklistRepository)
        {
            this.ChecklistRepository = checklistRepository;
            ChecklistRepositoryAARest = checklistRepository;

            ChecklistRepositoryAARest.Context = new ContextParameter()
            {
                AppId = contextEntity.App,
                AgencyName = contextEntity.Agency,
                ServiceProvCode = contextEntity.ServProvCode,
                AgencyUserId = contextEntity.ContextUser.Id.ToString(),
                AgencyUserName = contextEntity.ContextUser.LoginName,
                EnvironmnetName = contextEntity.EnvName,
                Language = contextEntity.Language,
                Token = contextEntity.SocialToken
            };
        }

        private readonly IChecklistRepository ChecklistRepository;
       
        private readonly IChecklistRepository ChecklistRepositoryAARest;
        

        public GetChecklistGroupResponse GetChecklistGroups(GetChecklistGroupRequest getChecklistGroupRequest)
        {
            var getChecklistGroupResponses = new GetChecklistGroupResponse();
            Pagination pageInfo;
            var checklistGroups = ChecklistRepository.GetChecklistGroups(getChecklistGroupRequest.Offset, getChecklistGroupRequest.Limit, out pageInfo);
            getChecklistGroupResponses.ChecklistGroups = checklistGroups;
            getChecklistGroupResponses.PageInfo = pageInfo;

            return getChecklistGroupResponses;
        }

        /// <summary>
        /// Get CheckList Groups from AARest API.
        /// </summary>
        /// <param name="getChecklistGroupRequest"></param>
        /// <returns>return checklist groups</returns>
        public GetChecklistGroupResponse GetChecklistGroups()
        {
            var getChecklistGroupResponses = new GetChecklistGroupResponse();
            Pagination pageInfo;
            var checklistGroups = ChecklistRepositoryAARest.GetChecklistGroups(0, 0, out pageInfo);
            getChecklistGroupResponses.ChecklistGroups = checklistGroups;
            getChecklistGroupResponses.PageInfo = pageInfo;
            return getChecklistGroupResponses;
        }

        public GetChecklistItemResponse GetChecklistItems(GetChecklistItemRequest getChecklistItemRequest)
        {
            var getChecklistItemResponse = new GetChecklistItemResponse();
            Pagination pageInfo;
            var checklistItemModels = ChecklistRepository.GetChecklistItems(getChecklistItemRequest.ChecklistID, getChecklistItemRequest.Offset, getChecklistItemRequest.Limit, out pageInfo);
            getChecklistItemResponse.ChecklistItemModels = checklistItemModels;
            getChecklistItemResponse.PageInfo = pageInfo;
            return getChecklistItemResponse;
        }

        public GetChecklistResponse GetChecklists(GetChecklistRequest getChecklistRequest)
        {
            var getChecklistResponse = new GetChecklistResponse();
            Pagination pageInfo;
            var checklistModels = ChecklistRepository.GetChecklists(getChecklistRequest.GroupID, getChecklistRequest.Offset, getChecklistRequest.Limit, out pageInfo);
            getChecklistResponse.checklistModels = checklistModels;
            getChecklistResponse.PageInfo = pageInfo;
            return getChecklistResponse;
        }
    }
}
