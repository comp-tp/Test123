using System;
using System.Collections.Generic;
using System.Threading;
using Accela.Apps.Apis.Models.DomainModels.ChecklistModels;
using Accela.Apps.Apis.Repositories.Interfaces;
using Accela.Apps.Shared;
using Accela.Apps.Apis.Repositories.GovXmlHelpers;
using System.Threading.Tasks;
using Accela.Core.Ioc;
using Accela.Apps.Shared.Contexts;

namespace Accela.Apps.Apis.Repositories.Agency
{
    public sealed class ChecklistCache : CacheBase
    {
        private const string KEY_CHECKLISTS = "Checklists";
        private const string KEY_CHECKLISTGROUPS = "ChecklistGroups";

        //private static IAgencyAppContext agencyAppContext = ServiceLocator.Resolve<IAgencyAppContext>();
        private static readonly ChecklistCache instance = new ChecklistCache();

        private IMobileEntityRepository<ChecklistModel> _checklistMECache;
        private IMobileEntityRepository<ChecklistGroupModel> _checklistGroupMECache;

        private ChecklistCache(): base()
        {
            _checklistMECache = IocContainer.Resolve<IMobileEntityRepository<ChecklistModel>>();
            _checklistGroupMECache = IocContainer.Resolve<IMobileEntityRepository<ChecklistGroupModel>>();
        }

        public static ChecklistCache Instance
        {
            get
            {
                return instance;
            }
        }

        public void CacheChecklist(List<ChecklistModel> checklists, IAgencyAppContext agencyContext)
        {
            var watch = Reflection.Startwatch();
            if (checklists != null && checklists.Count > 0)
            {
                List<ChecklistModel> cloneChecklists = JsonConverter.CloneObject<List<ChecklistModel>>(checklists);
                //var clone = Context.Clone();

                Task.Factory.StartNew(() =>
                {
                    try
                    {
                        //Context.SetContext(clone);
                        CacheChecklistUtility(cloneChecklists, agencyContext);
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            Log.Error(ex, "ChecklistCache.CacheChecklist");
                        }
                        catch { }
                    }
                });
            }

            // TODO:
            // Use the new DLL
            // Remove the below code later because there is no such thing in the new DLL.
            //Log.Performance(Reflection.CurrentMethodName, Reflection.Stopwatch(watch), "Performance - CacheChecklist()");
        }

        public void CacheChecklistGroup(List<ChecklistGroupModel> checklistGroups, IAgencyAppContext agencyContext)
        {
            var watch = Reflection.Startwatch();
            if (checklistGroups != null && checklistGroups.Count > 0)
            {
                List<ChecklistGroupModel> cloneChecklistGroups = JsonConverter.CloneObject<List<ChecklistGroupModel>>(checklistGroups);
                //var clone = Context.Clone();

                Task.Factory.StartNew(() =>
                {
                    try
                    {
                        //Context.SetContext(clone);
                        CacheChecklistGroupUtility(cloneChecklistGroups, agencyContext);
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            Log.Error(ex, "ChecklistCache.CacheCheckGrouplist");
                        }
                        catch { }
                    }
                });
            }

            // TODO:
            // Use the new DLL
            // Remove the below code later because there is no such thing in the new DLL.
            //Log.Performance(Reflection.CurrentMethodName, Reflection.Stopwatch(watch), "Performance - CacheCheckGrouplist()");
        }

        public List<ChecklistModel> GetChecklists(IAgencyAppContext agencyContext)
        {
            List<ChecklistModel> checklistModels = null;

            if (agencyContext.ContextUser != null)
            {
                var scope = QueryHelpler.GetEntityScope(EntityTypes.Checklist, agencyContext);
                var cacheKey = KEY_CHECKLISTS;
                checklistModels = _checklistMECache.GetObjectById<List<ChecklistModel>>(scope, cacheKey);
            }

            return checklistModels;
        }

        public List<ChecklistGroupModel> GetChecklistGroups(IAgencyAppContext agencyContext)
        {
            List<ChecklistGroupModel> checklistGroupModels = null;

            if (agencyContext.ContextUser != null)
            {
                var scope = QueryHelpler.GetEntityScope(EntityTypes.ChecklistGroup, agencyContext);
                var cacheKey = KEY_CHECKLISTGROUPS;
                checklistGroupModels = _checklistGroupMECache.GetObjectById<List<ChecklistGroupModel>>(scope, cacheKey);
            }

            return checklistGroupModels;
        }

        private void CacheChecklistUtility(List<ChecklistModel> checklists, IAgencyAppContext agencyContext)
        {
            if (checklists != null)
            {
                var scope = QueryHelpler.GetEntityScope(EntityTypes.Checklist, agencyContext);
                var cacheKey = KEY_CHECKLISTS;
                var cacheData = JsonConverter.ToJson(checklists);
                var entity = this.BuildMobileEntity(scope, cacheKey, cacheData);
                this._checklistMECache.DeleteEntity(entity);
                this._checklistMECache.InsertEntity(entity);
            }
        }

        private void CacheChecklistGroupUtility(List<ChecklistGroupModel> checklistGroups, IAgencyAppContext agencyContext)
        {
            if (checklistGroups != null)
            {
                var scope = QueryHelpler.GetEntityScope(EntityTypes.ChecklistGroup, agencyContext);
                var cacheKey = KEY_CHECKLISTGROUPS;
                var cacheData = JsonConverter.ToJson(checklistGroups);
                var entity = this.BuildMobileEntity(scope, cacheKey, cacheData);
                this._checklistGroupMECache.DeleteEntity(entity);
                this._checklistGroupMECache.InsertEntity(entity);
            }
        }

    }
}
