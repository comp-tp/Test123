using System.Collections.Generic;
using System.Linq;
using Accela.Apps.Apis.Models.DomainModels.ChecklistModels;
using Accela.Apps.Apis.Models.DTOs;
using Accela.Apps.Apis.Repositories.GovXmlHelpers;
using Accela.Apps.Apis.Repositories.Interfaces;
using Accela.Automation.GovXmlClient.Model;
using Accela.Apps.Shared;
using Accela.Apps.Shared.Contexts;

namespace Accela.Apps.Apis.Repositories.Agency
{
    public class ChecklistRepository : RepositoryBase, IChecklistRepository
    {
        public ContextParameter Context
        {
            get;
            set;
        }

        //public ChecklistRepository(string appId, string agencyName, string serviceProvCode, string agencyUserId, string agencyUsername, string token, string environmentName, string language)
        //    : base(appId, agencyName, serviceProvCode, agencyUserId, agencyUsername, token, environmentName, language)
        //{
        //}

        public ChecklistRepository(IAgencyAppContext contextEntity)
            : base(contextEntity)
        {

        }

        public List<ChecklistModel> GetChecklists(int offset, int limit)
        {
            List<ChecklistModel> checklistModels = ChecklistCache.Instance.GetChecklists(this.CurrentContext);

            if (checklistModels == null || checklistModels.Count == 0)
            {
                GovXML govXmlIn = new GovXML();
                govXmlIn.getGuidesheets = new GetGuidesheets();
                govXmlIn.getGuidesheets.system = CommonHelper.GetSystemFromPosition(offset, limit, this.CurrentContext);

                GovXML response = CommonHelper.Post(govXmlIn,
                        govXmlIn.getGuidesheets.system,
                        (o) => o.getGuidesheetsResponse == null ? null : o.getGuidesheetsResponse.system);

                if (response != null && response.getGuidesheetsResponse != null && response.getGuidesheetsResponse.guidesheets != null)
                {
                    checklistModels = ChecklistHelper.GetClientChecklists(response.getGuidesheetsResponse.guidesheets);
                    ChecklistCache.Instance.CacheChecklist(checklistModels, this.CurrentContext);
                }
            }

            return checklistModels;
        }

        public List<ChecklistGroupModel> GetChecklistGroups(int offset, int limit, out Pagination pagination)
        {
            List<ChecklistGroupModel> checkListGroups = ChecklistCache.Instance.GetChecklistGroups(this.CurrentContext);
            if (checkListGroups == null || checkListGroups.Count == 0)
            {
                var checkLists = GetChecklists(offset, limit);
                if (checkLists != null && checkLists.Count > 0)
                {
                    checkListGroups = new List<ChecklistGroupModel>();
                    foreach (var checkList in checkLists)
                    {
                        checkListGroups.AddRange(checkList.ChecklistGroups);
                    }
                    checkListGroups = checkListGroups.Distinct<ChecklistGroupModel>(new ChecklistGroupComparer()).ToList();

                    ChecklistCache.Instance.CacheChecklistGroup(checkListGroups, this.CurrentContext);
                }
            }

            pagination = new Pagination();
            if (checkListGroups != null && checkListGroups.Count > 0)
            {
                pagination.Offset = offset;
                pagination.TotalRows = checkListGroups.Count;

                checkListGroups = checkListGroups.Skip(offset).Take(limit).ToList();
                pagination.Limit = checkListGroups.Count;
            }

            return checkListGroups;
        }

        public List<ChecklistItemModel> GetChecklistItems(string checklistID, int offset, int limit, out Pagination pagination)
        {
            List<ChecklistItemModel> checklistItemModels = new List<ChecklistItemModel>();

            var checkLists = GetChecklists(offset, limit);
            if (checkLists != null && checkLists.Count > 0)
            {
                var checklist = checkLists.Find(c => c.Identifier == checklistID);
                if (checklist != null)
                {
                    if (checklist.ChecklistItems != null && checklist.ChecklistItems.Count > 0)
                    {
                        checklistItemModels.AddRange(checklist.ChecklistItems);
                    }
                }
            }

            pagination = new Pagination();

            if (checklistItemModels != null && checklistItemModels.Count > 0)
            {
                pagination.Offset = offset;
                pagination.TotalRows = checklistItemModels.Count;

                checklistItemModels = checklistItemModels.Skip(offset).Take(limit).ToList();
                pagination.Limit = checklistItemModels.Count;
            }

            return checklistItemModels;
        }

        public List<ChecklistModel> GetChecklists(string groupID, int offset, int limit, out Pagination pagination)
        {
            var checklistModels = GetChecklists(offset, limit);
            if (checklistModels != null && checklistModels.Count > 0)
            {
                if (!string.IsNullOrEmpty(groupID))
                {
                    checklistModels = checklistModels.FindAll(c => c.ChecklistGroups.Any(g => g.Identifier == groupID));
                }
            }

            pagination = new Pagination();
            if (checklistModels != null && checklistModels.Count > 0)
            {
                pagination.Offset = offset;
                pagination.TotalRows = checklistModels.Count;

                checklistModels = checklistModels.Skip(offset).Take(limit).ToList();
                pagination.Limit = checklistModels.Count;
            }

            return checklistModels;
        }

    }
}
