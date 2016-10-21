using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Accela.Apps.Apis.Models.DomainModels.AdditionalModels;
using Accela.Apps.Apis.Models.DomainModels.AssetModels;
using Accela.Apps.Apis.Models.DomainModels.CommentModels;
using Accela.Apps.Apis.Models.DomainModels.ContactModels;
using Accela.Apps.Apis.Models.DomainModels.InspectionModels;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;
using Accela.Apps.Apis.Models.DomainModels.StandardChoicesModels;
using Accela.Apps.Apis.Repositories.GovXmlHelpers;
using Accela.Apps.Apis.Repositories.Interfaces;
using Accela.Apps.Shared;
using System.Threading.Tasks;
using Accela.Core.Ioc;
using Accela.Apps.Shared.Contexts;

namespace Accela.Apps.Apis.Repositories.Agency
{
    public class ReferenceDataCache : CacheBase
    {
        private const string KEY_INSPECTION_TYPES = "InspectionTypes";
        private const string KEY_STANDARD_COMMENT_GROUPS = "StandardCommentGroups";
        private const string KEY_STANDARD_COMMENTS = "StandardComments";
        private const string KEY_DEPARTMENTS = "DEPARTMENTS";
        private const string KEY_RECORD_TYPE = "RECORDTYPE";
        private const string KEY_ASI_ASIT = "ASI_ASIT";
        private const string KEY_ASSET_ASI_AND_ASIT = "AssetASIAndASIT";
        private const string KEY_ASSET_TYPE = "AssetType";
        private const string KEY_ASSET_CA_TYPE = "AssetCAType";
        private const string KEY_SYSTEM_INSPECTOR = "SystemInspector";
        private const string KEY_SYSTEM_ALL_DEPARTMENTS = "SYSTEM_ALL_DEPARMENTS";
        private const string KEY_INSPECTION_GROUP = "InspectionGroup";
        private const string KEY_RECORD_TEMPLATES = "RECORD_TEMPLATES";
        private const string KEY_CONTACT_TYPE = "SYSTEMCONTACTTYPE";
        private const string KEY_I18N_LANGUAGES = "I18N_LANGUAGES";

        //private static IAgencyAppContext agencyAppContext = ServiceLocator.Resolve<IAgencyAppContext>();
        private static readonly ReferenceDataCache _instance = new ReferenceDataCache();

        private IMobileEntityRepository<InspectionTypeModel> _inspectionRefTypeMECache;
        private IMobileEntityRepository<StandardCommentGroupModel> _standardCommentGroupMECache;
        private IMobileEntityRepository<StandardCommentModel> _standardCommentMECache;
        private IMobileEntityRepository<DepartmentModel> _departmentMECache;
        private IMobileEntityRepository<RecordTypeModel> _recordTypeMECache;
        private IMobileEntityRepository<AdditionalGroupModel> _additionalGroupMECache;
        private IMobileEntityRepository<AdditionalGroupModel> _assetASIAndASITMECache;
        private IMobileEntityRepository<AssetTypeModel> _assetTypeCache;
        private IMobileEntityRepository<AssetCATypeModel> _assetCATypeCache;
        private IMobileEntityRepository<InspectionGroupModel> _inspectionGroupCache;
        private IMobileEntityRepository<SystemInspectorModel> _systemInspectorsCache;
        private IMobileEntityRepository<SystemDepartmentModel> _systemAllDepartmentsCache;
        private IMobileEntityRepository<WorkOrderTemplateModel> _templatesCache; 
        private IMobileEntityRepository<ContactRoleModel> _systemContactTypeCache;


        /// <summary>
        /// Inspection cache class's structor.
        /// </summary>
        private ReferenceDataCache(): base()
        {
            _inspectionRefTypeMECache = IocContainer.Resolve<IMobileEntityRepository<InspectionTypeModel>>();
            _standardCommentGroupMECache = IocContainer.Resolve<IMobileEntityRepository<StandardCommentGroupModel>>();
            _standardCommentMECache = IocContainer.Resolve<IMobileEntityRepository<StandardCommentModel>>();
            _departmentMECache = IocContainer.Resolve<IMobileEntityRepository<DepartmentModel>>();
            _recordTypeMECache = IocContainer.Resolve<IMobileEntityRepository<RecordTypeModel>>();
            _additionalGroupMECache = IocContainer.Resolve<IMobileEntityRepository<AdditionalGroupModel>>();
            _assetASIAndASITMECache = IocContainer.Resolve<IMobileEntityRepository<AdditionalGroupModel>>();
            _assetTypeCache = IocContainer.Resolve<IMobileEntityRepository<AssetTypeModel>>();
            _assetCATypeCache = IocContainer.Resolve<IMobileEntityRepository<AssetCATypeModel>>();
            _systemInspectorsCache = IocContainer.Resolve<IMobileEntityRepository<SystemInspectorModel>>();
            _systemAllDepartmentsCache = IocContainer.Resolve<IMobileEntityRepository<SystemDepartmentModel>>();
            _inspectionGroupCache = IocContainer.Resolve<IMobileEntityRepository<InspectionGroupModel>>();
            _templatesCache = IocContainer.Resolve<IMobileEntityRepository<WorkOrderTemplateModel>>();
            _systemContactTypeCache = IocContainer.Resolve<IMobileEntityRepository<ContactRoleModel>>();
        }

        /// <summary>
        /// Get SystemCache instance.
        /// </summary>
        public static ReferenceDataCache Instance
        {
            get
            {
                return _instance;
            }
        }

        /// <summary>
        /// Caches the inspection types.
        /// </summary>
        /// <param name="cloudUser">the cloud user.</param>
        /// <param name="inspectionTypes">The inspection types.</param>
        public void CacheInspectionTypes(IList<InspectionTypeModel> inspectionTypes, IAgencyAppContext agencyContext)
        {
            if (inspectionTypes != null && inspectionTypes.Count > 0)
            {
                var cacheData = JsonConverter.ToJson(inspectionTypes);

                //var clone = Context.Clone();

                //Task.Factory.StartNew(() =>
                //{
                    try
                    {
                        //Context.SetContext(clone);
                        var scope = QueryHelpler.GetEntityScope(EntityTypes.InspectionRefType, agencyContext);
                        var cacheKey = this.GetCacheKey(EntityTypes.InspectionRefType, null);
                        var entity = this.BuildMobileEntity(scope, cacheKey, cacheData);
                        this._inspectionRefTypeMECache.DeleteEntity(entity);
                        this._inspectionRefTypeMECache.InsertEntity(entity);
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            Log.Error(ex, "ReferenceDataCache.CacheInspectionTypes");
                        }
                        catch { }
                    }
                //});
            }
        }

        /// <summary>
        /// Gets the inspetion types.
        /// </summary>
        /// <returns>the inspetion types.</returns>
        public IList<InspectionTypeModel> GetInspetionTypes(IAgencyAppContext agencyContext)
        {
            var scope = QueryHelpler.GetEntityScope(EntityTypes.InspectionRefType, agencyContext);
            var entityList = _inspectionRefTypeMECache.GetObjectById<IList<InspectionTypeModel>>(scope, KEY_INSPECTION_TYPES);
            return entityList;
        }


        /// <summary>
        /// Gets the system inspetors
        /// </summary>
        /// <returns>the inspetion types.</returns>
        public IList<SystemInspectorModel> GetInspectors(IAgencyAppContext agencyContext)
        {
            var scope = QueryHelpler.GetEntityScope(EntityTypes.SystemInspector, agencyContext);
            var entityList = _systemInspectorsCache.GetObjectById<IList<SystemInspectorModel>>(scope, KEY_SYSTEM_INSPECTOR);
            return entityList;
        }


        /// <summary>
        /// Caches the departments.
        /// </summary>
        /// <param name="cloudUser">Cloud User.</param>
        /// <param name="departmentModels">The department models.</param>
        public void CacheDepartments(IList<DepartmentModel> departmentModels, IAgencyAppContext agencyContext)
        {
            if (departmentModels != null && departmentModels.Count > 0)
            {
                var cacheData = JsonConverter.ToJson(departmentModels);
                //var clone = Context.Clone();
                //Task.Factory.StartNew(() =>
                //{
                    try
                    {
                       // Context.SetContext(clone);
                        var scope = QueryHelpler.GetEntityScope(EntityTypes.DepartmentWithInspector, agencyContext);
                        var cacheKey = this.GetCacheKey(EntityTypes.InspectionRefType, null);
                        var entity = this.BuildMobileEntity(scope, cacheKey, cacheData);
                        this._departmentMECache.DeleteEntity(entity);
                        this._departmentMECache.InsertEntity(entity);
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            Log.Error(ex, "ReferenceDataCache.CacheDepartments");
                        }
                        catch { }
                    }
                //});
            }
        }


        /// <summary>
        /// Caches the system departments(and all departments and its staffs).
        /// </summary>
        public void CacheSystemDepartments(IList<SystemDepartmentModel> systemDepartmentModels, IAgencyAppContext agencyContext)
        {
            if (systemDepartmentModels != null && systemDepartmentModels.Count > 0)
            {
                var cacheData = JsonConverter.ToJson(systemDepartmentModels);
                //var clone = Context.Clone();
                //Task.Factory.StartNew(() =>
                //{
                    try
                    {
                        //Context.SetContext(clone);
                        var scope = QueryHelpler.GetEntityScope(EntityTypes.SystemDepartment, agencyContext);
                        var cacheKey = this.GetCacheKey(EntityTypes.SystemDepartment, null);
                        var entity = this.BuildMobileEntity(scope, cacheKey, cacheData);
                        this._systemAllDepartmentsCache.DeleteEntity(entity);
                        this._systemAllDepartmentsCache.InsertEntity(entity);
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            Log.Error(ex, "ReferenceDataCache.CacheSystemDepartments");
                        }
                        catch { }
                    }
                //});

            }
        }

        /// <summary>
        /// Gets the departments.
        /// </summary>
        /// <returns>the departments.</returns>
        public IList<DepartmentModel> GetDepartments(IAgencyAppContext agencyContext)
        {
            var scope = QueryHelpler.GetEntityScope(EntityTypes.DepartmentWithInspector, agencyContext);
            var entityList = _departmentMECache.GetObjectById<IList<DepartmentModel>>(scope, KEY_DEPARTMENTS);
            return entityList;
        }


        /// <summary>
        /// Gets all system departments (and it's staffs).
        /// </summary>
        /// <returns>the departments.</returns>
        public IList<SystemDepartmentModel> GetAllSystemDepartments(IAgencyAppContext agencyContext)
        {
            var scope = QueryHelpler.GetEntityScope(EntityTypes.SystemDepartment, agencyContext);
            var entityList = _systemAllDepartmentsCache.GetObjectById<IList<SystemDepartmentModel>>(scope, KEY_SYSTEM_ALL_DEPARTMENTS);
            return entityList;
        }

        /// <summary>
        /// Caches the standard comment related data.
        /// </summary>
        /// <param name="standardCommentGroupModels">The standard comment group models.</param>
        /// <param name="agency">The agency.</param>
        public void CacheStandardCommentRelatedData(List<StandardCommentModel> standardCommentModels, IAgencyAppContext agencyContext)
        {
            List<StandardCommentModel> cloneStdComments = JsonConverter.CloneObject<List<StandardCommentModel>>(standardCommentModels);
            //var clone = Context.Clone();
            //Task.Factory.StartNew(() =>
            //{
                try
                {
                    //Context.SetContext(clone);
                    if (cloneStdComments != null && cloneStdComments.Count > 0)
                    {
                        CacheStandardCommentGroups(cloneStdComments, agencyContext);
                        CacheStandardComments(cloneStdComments, agencyContext);
                    }
                }
                catch (Exception ex)
                {
                    try
                    {
                        Log.Error(ex, "ReferenceDataCache.CacheStandardCommentRelatedData");
                    }
                    catch { }
                }
            //});
        }

        /// <summary>
        /// Caches the standard comment groups.
        /// </summary>
        /// <param name="cloudUser">The current cloud user.</param>
        /// <param name="standardCommentModels">The standard comment models.</param>
        private void CacheStandardCommentGroups(IList<StandardCommentModel> standardCommentModels, IAgencyAppContext agencyContext)
        {
            if (standardCommentModels != null && standardCommentModels.Count > 0)
            {
                var tempGroupResult = from c in standardCommentModels
                                      where c != null
                                      && c.CommentGroup != null
                                      group c.CommentGroup by c.CommentGroup.Identifier into commentGroup
                                      select commentGroup.First();
                var standardCommentGroups = tempGroupResult.ToList();

                var scope = QueryHelpler.GetEntityScope(EntityTypes.StandardCommentGroup, agencyContext);
                var cacheKey = this.GetCacheKey(EntityTypes.StandardCommentGroup, null);
                var cacheData = JsonConverter.ToJson(standardCommentGroups);
                var entity = this.BuildMobileEntity(scope, cacheKey, cacheData);
                this._standardCommentGroupMECache.DeleteEntity(entity);
                this._standardCommentGroupMECache.InsertEntity(entity);
            }
        }

        /// <summary>
        /// Caches the standard comments.
        /// </summary>
        /// <param name="cloudUser">The current cloud user.</param>
        /// <param name="standardCommentModels">The standard comment models.</param>
        private void CacheStandardComments(IList<StandardCommentModel> standardCommentModels, IAgencyAppContext agencyContext)
        {
            if (standardCommentModels != null && standardCommentModels.Count > 0)
            {
                var scope = QueryHelpler.GetEntityScope(EntityTypes.StandardComment, agencyContext);

                var standCommentList = new List<StandardCommentModel>();
                var groupComments = from c in standardCommentModels
                                    where c != null
                                    && c.CommentGroup != null
                                    group c by c.CommentGroup.Identifier into commentGroup
                                    let groupCommentList = (from gc in commentGroup select gc).ToList()
                                    select groupCommentList;

                foreach (var groupComment in groupComments)
                {
                    standCommentList.AddRange(groupComment);
                }

                var standardCommentKey = KEY_STANDARD_COMMENTS;
                var standardCommentsCacheData = JsonConverter.ToJson(standCommentList);
                var mobileEntity = this.BuildMobileEntity(scope, standardCommentKey, standardCommentsCacheData);
                this._standardCommentMECache.DeleteEntity(mobileEntity);
                this._standardCommentMECache.InsertEntity(mobileEntity);
            }
        }

        /// <summary>
        /// Gets the standard comment groups.
        /// </summary>
        /// <returns>the standard comment groups.</returns>
        public IList<StandardCommentGroupModel> GetStandardCommentGroups(IAgencyAppContext agencyContext)
        {
            var scope = QueryHelpler.GetEntityScope(EntityTypes.StandardCommentGroup, agencyContext);
            var entityList = _standardCommentGroupMECache.GetObjectById<IList<StandardCommentGroupModel>>(scope, KEY_STANDARD_COMMENT_GROUPS);
            return entityList;
        }

        /// <summary>
        /// Gets the standard comments.
        /// </summary>
        /// <returns>the standard comments.</returns>
        public IList<StandardCommentModel> GetStandardComments(IAgencyAppContext agencyContext)
        {
            var scope = QueryHelpler.GetEntityScope(EntityTypes.StandardComment, agencyContext);
            var entityList = _standardCommentMECache.GetObjectById<IList<StandardCommentModel>>(scope, KEY_STANDARD_COMMENTS);
            return entityList;
        }

        /// <summary>
        /// Caches the record types.
        /// </summary>
        /// <param name="recordTypes">The record types.</param>
        public void CacheRecordTypes(IList<RecordTypeModel> recordTypes, string module, IAgencyAppContext agencyContext)
        {
            if (module == null)
                module = "";
            if (recordTypes != null && recordTypes.Count > 0)
            {
                var cacheData = JsonConverter.ToJson(recordTypes);

                //var clone = Context.Clone();

                //Task.Factory.StartNew(() =>
                //{
                    try
                    {
                        //Context.SetContext(clone);
                        var scope = QueryHelpler.GetEntityScope(EntityTypes.RecordType, agencyContext);
                        var cacheKey = this.GetCacheKey(EntityTypes.RecordType, null);
                        var entity = this.BuildMobileEntity(scope, cacheKey + "-" + module.ToUpper(), cacheData);
                        this._recordTypeMECache.DeleteEntity(entity);
                        this._recordTypeMECache.InsertEntity(entity);
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            Log.Error(ex, "ReferenceDataCache.CacheRecordTypes");
                        }
                        catch { }
                    }
                //});
            }
        }

        /// <summary>
        /// Gets the record types.
        /// </summary>
        /// <returns>the record types.</returns>
        public IList<RecordTypeModel> GetRecordTypes(string module, IAgencyAppContext agencyContext)
        {
            if (module == null)
                module = "";

            var scope = QueryHelpler.GetEntityScope(EntityTypes.RecordType, agencyContext);
            var entityList = _recordTypeMECache.GetObjectById<IList<RecordTypeModel>>(scope, KEY_RECORD_TYPE + "-" + module.ToUpper());
            return entityList;
        }

        /// <summary>
        /// cache the inspcetion group
        /// </summary>
        /// <param name="inspectionGroups"></param>
        public void CacheInspectionGroups(IList<InspectionGroupModel> inspectionGroups, IAgencyAppContext agencyContext)
        {
            if (inspectionGroups != null && inspectionGroups.Count > 0)
            {
                var cacheData = JsonConverter.ToJson(inspectionGroups);

                //var clone = Context.Clone();

                //Task.Factory.StartNew(async () =>
                //{
                    try
                    {
                        //Context.SetContext(clone);
                        var scope = QueryHelpler.GetEntityScope(EntityTypes.InspectionGroup, agencyContext);
                        var cacheKey = this.GetCacheKey(EntityTypes.InspectionGroup, null);
                        var entity = this.BuildMobileEntity(scope, cacheKey, cacheData);
                        this._inspectionGroupCache.DeleteEntity(entity);
                  
                        this._inspectionGroupCache.InsertEntity(entity); 
   
                        //await this._inspectionGroupCache.InsertEntity(entity);                   
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            Log.Error(ex, "ReferenceDataCache.CacheInspectionGroups");
                        }
                        catch { }
                    }
                //});
            }     
        }


        /// <summary>
        /// Caches the additional groups (include ASI and ASIT).
        /// </summary>
        /// <param name="additionalGroups">The additional groups.</param>
        public void CacheAdditionalGroups(IList<AdditionalGroupModel> additionalGroups, IAgencyAppContext agencyContext)
        {
            if (additionalGroups != null && additionalGroups.Count > 0)
            {
                var cacheData = JsonConverter.ToJson(additionalGroups);

                //var clone = Context.Clone();

                //Task.Factory.StartNew(() =>
                //{
                try
                {
                        //Context.SetContext(clone);
                        var scope = QueryHelpler.GetEntityScope(EntityTypes.ASIAndASIT, agencyContext);
                        var cacheKey = this.GetCacheKey(EntityTypes.ASIAndASIT, null);
                        var entity = this.BuildMobileEntity(scope, cacheKey, cacheData);
                        this._additionalGroupMECache.DeleteEntity(entity);
                        this._additionalGroupMECache.InsertEntity(entity);
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            Log.Error(ex, "ReferenceDataCache.CacheAdditionalGroups");
                        }
                        catch { }
                    }
                //});
            }
        }

        /// <summary>
        /// Gets the inspection group.
        /// </summary>
        public IList<InspectionGroupModel> GetInspectionGroups(IAgencyAppContext agencyContext)
        {
            var scope = QueryHelpler.GetEntityScope(EntityTypes.InspectionGroup, agencyContext);
            return _inspectionGroupCache.GetObjectById<IList<InspectionGroupModel>>(scope, KEY_INSPECTION_GROUP);
            //return entityList;
        }

        /// <summary>
        /// Caches the system Inspectors.
        /// </summary>
        public void CacheSystemInspectors(IList<SystemInspectorModel> inspectors, IAgencyAppContext agencyContext)
        {
            if (inspectors != null && inspectors.Count > 0)
            {
                var cacheData = JsonConverter.ToJson(inspectors);
                //var clone = Context.Clone();
                //Task.Factory.StartNew(() =>
                //{
                    try
                    {
                        //Context.SetContext(clone);
                        var scope = QueryHelpler.GetEntityScope(EntityTypes.SystemInspector, agencyContext);
                        var cacheKey = this.GetCacheKey(EntityTypes.SystemInspector, null);
                        var entity = this.BuildMobileEntity(scope, cacheKey, cacheData);
                        this._systemInspectorsCache.DeleteEntity(entity);
                        this._systemInspectorsCache.InsertEntity(entity);
                         
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            Log.Error(ex, "ReferenceDataCache.CacheSystemInspectors");
                        }
                        catch { }
                    }
                //});
            }
        }

        /// <summary>
        /// Gets the additional groups.
        /// </summary>
        /// <returns>the additional groups.</returns>
        public IList<AdditionalGroupModel> GetAdditionalGroups(IAgencyAppContext agencyContext)
        {
            var scope = QueryHelpler.GetEntityScope(EntityTypes.ASIAndASIT, agencyContext);
            var entityList = _additionalGroupMECache.GetObjectById<IList<AdditionalGroupModel>>(scope, KEY_ASI_ASIT);
            return entityList;
        }

        /// <summary>
        /// Caches the asset ASI and ASITs.
        /// </summary>
        /// <param name="additionalGroups">The additional groups.</param>
        public void CacheAssetASIAndASITs(IList<AdditionalGroupModel> additionalGroups, IAgencyAppContext agencyContext)
        {
            if (additionalGroups != null && additionalGroups.Count > 0)
            {
                var cacheData = JsonConverter.ToJson(additionalGroups);

                //var clone = Context.Clone();

                //Task.Factory.StartNew(() =>
                //{
                    try
                    {
                        //Context.SetContext(clone);
                        var scope = QueryHelpler.GetEntityScope(EntityTypes.AssetASIAndASIT, agencyContext);
                        var cacheKey = this.GetCacheKey(EntityTypes.AssetASIAndASIT, null);
                        var entity = this.BuildMobileEntity(scope, cacheKey, cacheData);
                        this._assetASIAndASITMECache.DeleteEntity(entity);
                        this._assetASIAndASITMECache.InsertEntity(entity);
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            Log.Error(ex, "ReferenceDataCache.CacheAssetASIAndASITs");
                        }
                        catch { }
                    }
                //});

            }
        }

        /// <summary>
        /// Gets the asset ASI and ASITs.
        /// </summary>
        /// <returns>the asset attribute templates.</returns>
        public IList<AdditionalGroupModel> GetAssetASIAndASITs(IAgencyAppContext agencyContext)
        {
            var scope = QueryHelpler.GetEntityScope(EntityTypes.AssetASIAndASIT, agencyContext);
            var entityList = _assetASIAndASITMECache.GetObjectById<IList<AdditionalGroupModel>>(scope, KEY_ASSET_ASI_AND_ASIT);
            return entityList;
        }

        /// <summary>
        /// Caches the asset Asset types.
        /// </summary>
        /// <param name="assetTypes">Asset types.</param>
        public void CacheAssetTypes(IList<AssetTypeModel> assetTypes, IAgencyAppContext agencyContext)
        {
            if (assetTypes != null && assetTypes.Count > 0)
            {
                var cacheData = JsonConverter.ToJson(assetTypes);

                //var clone = Context.Clone();

                //Task.Factory.StartNew(() =>
                //{
                    try
                    {
                        //Context.SetContext(clone);
                        var scope = QueryHelpler.GetEntityScope(EntityTypes.AssetType, agencyContext);
                        var cacheKey = this.GetCacheKey(EntityTypes.AssetType, null);
                        var entity = this.BuildMobileEntity(scope, cacheKey, cacheData);
                        this._assetTypeCache.DeleteEntity(entity);
                        this._assetTypeCache.InsertEntity(entity);
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            Log.Error(ex, "ReferenceDataCache.CacheAssetTypes");
                        }
                        catch { }
                    }
                //});
            }
        }

        /// <summary>
        /// Caches the asset Asset CA types.
        /// </summary>
        /// <param name="assetCATypes"></param>
        public void CachAssetCATypes(IList<AssetCATypeModel> assetCATypes, IAgencyAppContext agencyContext)
        {
            if (assetCATypes != null && assetCATypes.Count > 0)
            {
                var cacheData = JsonConverter.ToJson(assetCATypes);

                //var clone = Context.Clone();

                //Thread thread = new Thread(new ThreadStart(() =>
                //{
                    try
                    {
                        //Context.SetContext(clone);
                        var scope = QueryHelpler.GetEntityScope(EntityTypes.AssetCAType, agencyContext);
                        var cacheKey = this.GetCacheKey(EntityTypes.AssetCAType, null);
                        var entity = this.BuildMobileEntity(scope, cacheKey, cacheData);
                        this._assetCATypeCache.DeleteEntity(entity);
                        this._assetCATypeCache.InsertEntity(entity);
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            Log.Error(ex, "ReferenceDataCache.CachAssetCATypes");
                        }
                        catch { }
                    }
                //}));

                //thread.Start();
            }
        }

        /// <summary>
        /// Gets the asset types
        /// </summary>
        /// <returns>the asset type.</returns>
        public List<AssetTypeModel> GetAssetTypes(IAgencyAppContext agencyContext)
        {
            var scope = QueryHelpler.GetEntityScope(EntityTypes.AssetType, agencyContext);
            var entityList = _assetTypeCache.GetObjectById<List<AssetTypeModel>>(scope, KEY_ASSET_TYPE);
            return entityList;
        }

        /// <summary>
        /// Gets the assetCA types
        /// </summary>
        /// <param name="module"></param>
        /// <returns></returns>
        public List<AssetCATypeModel> GetAssetCATypes(IAgencyAppContext agencyContext)
        {
            var scope = QueryHelpler.GetEntityScope(EntityTypes.AssetCAType, agencyContext);
            var entityList = _assetCATypeCache.GetObjectById<List<AssetCATypeModel>>(scope, KEY_ASSET_CA_TYPE);
            return entityList;
        }

        internal IList<WorkOrderTemplateModel> GetTemplates(string module, IAgencyAppContext agencyContext)
        {
            if (module == null)
                module = "";

            var scope = QueryHelpler.GetEntityScope(EntityTypes.RecordTemplate, agencyContext);
            var cacheKey = this.GetCacheKey(EntityTypes.RecordTemplate, null);
            var entityList = _templatesCache.GetObjectById<IList<WorkOrderTemplateModel>>(scope, cacheKey + "-" + module.ToUpper());
            return entityList;
        }

        internal void CacheTemplates(IList<WorkOrderTemplateModel> allTemplates, string module, IAgencyAppContext agencyContext)
        {
            if (module == null)
                module = "";
            if (allTemplates != null && allTemplates.Count > 0)
            {
                var cacheData = JsonConverter.ToJson(allTemplates);

                //var clone = Context.Clone();

                //Task.Factory.StartNew(() =>
                //{
                    try
                    {
                        //Context.SetContext(clone);
                        var scope = QueryHelpler.GetEntityScope(EntityTypes.RecordTemplate, agencyContext);
                        var cacheKey = this.GetCacheKey(EntityTypes.RecordTemplate, null);
                        var entity = this.BuildMobileEntity(scope, cacheKey + "-" + module.ToUpper(), cacheData);
                        this._templatesCache.DeleteEntity(entity);
                        this._templatesCache.InsertEntity(entity);
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            Log.Error(ex, "ReferenceDataCache.CacheTemplates");
                        }
                        catch { }
                    }
                //});

            }
        }

        /// <summary>
        /// Gets the cache key.
        /// </summary>
        /// <param name="entityType">Type of the entity.</param>
        /// <param name="identifier">The identifier.</param>
        /// <returns>the cache key.</returns>
        private string GetCacheKey(EntityTypes entityType, string identifier)
        {
            string result = String.Empty;

            switch (entityType)
            {
                case EntityTypes.InspectionRefType:
                    result = KEY_INSPECTION_TYPES;
                    break;
                case EntityTypes.StandardCommentGroup:
                    result = KEY_STANDARD_COMMENT_GROUPS;
                    break;
                case EntityTypes.StandardComment:
                    result = String.Format("{0}_{1}", KEY_STANDARD_COMMENTS, identifier);
                    break;
                case EntityTypes.DepartmentWithInspector:
                    result = KEY_DEPARTMENTS;
                    break;
                case EntityTypes.RecordType:
                    result = KEY_RECORD_TYPE;
                    break;
                case EntityTypes.RecordTemplate:
                    result = KEY_RECORD_TEMPLATES;
                    break;
                case EntityTypes.ASIAndASIT:
                    result = KEY_ASI_ASIT;
                    break;
                case EntityTypes.AssetASIAndASIT:
                    result = KEY_ASSET_ASI_AND_ASIT;
                    break;
                case EntityTypes.AssetType:
                    result = KEY_ASSET_TYPE;
                    break;
                case EntityTypes.InspectionGroup:
                    result = KEY_INSPECTION_GROUP;
                    break;
                case EntityTypes.SystemInspector:
                    result = KEY_SYSTEM_INSPECTOR;
                    break;
                case EntityTypes.SystemDepartment:
                    result = KEY_SYSTEM_ALL_DEPARTMENTS;
                    break;
                case EntityTypes.SystemContactRole:
                    result = KEY_CONTACT_TYPE;
                    break;
                case EntityTypes.I18NLanguages:
                    result = KEY_I18N_LANGUAGES;
                    break;
                default:
                    result = identifier;
                    break;
            }

            return result;
        }

        public IList<ContactRoleModel> GetSystemContactTypes(IAgencyAppContext agencyContext)
        {
            var scope = QueryHelpler.GetEntityScope(EntityTypes.SystemContactRole, agencyContext);

            var contactTypes = _systemContactTypeCache.GetObjectById<IList<ContactRoleModel>>(scope, KEY_CONTACT_TYPE);

            return contactTypes;
        }

        public void CacheSystemContactTypes(IList<ContactRoleModel> contactTypes, IAgencyAppContext agencyContext)
        {
            if (contactTypes != null && contactTypes.Count > 0)
            {
                var cacheData = JsonConverter.ToJson(contactTypes);

                //var context = Context.Clone();

                //Task.Factory.StartNew(() =>
                //{
                    try
                    {
                        //Context.SetContext(context);

                        var scope = QueryHelpler.GetEntityScope(EntityTypes.SystemContactRole, agencyContext);

                        var cacheKey = this.GetCacheKey(EntityTypes.SystemContactRole, null);

                        var entity = this.BuildMobileEntity(scope, cacheKey, cacheData);

                        this._systemContactTypeCache.DeleteEntity(entity);

                        this._systemContactTypeCache.InsertEntity(entity);
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            Log.Error(ex, "ReferenceDataCache.CacheSystemContactTypes");
                        }
                        catch
                        {
                        }
                    }
                //});
            }
        }

        //public IList<StandardChoicesModel> GetI18NLanguageSettings()
        //{
        //    var scope = QueryHelpler.GetEntityScope(EntityTypes.I18NLanguages);
        //    var entityList = _inspectionRefTypeMECache.GetObjectById<IList<StandardChoicesModel>>(scope, KEY_I18N_LANGUAGES);
        //    return entityList;
        //}

        //public void CacheI18NLanguageSettings(IList<StandardChoicesModel> settings)
        //{
        //    if (settings == null || settings.Count <= 0) return;

        //    var cacheData = JsonConverter.ToJson(settings);

        //    var clone = Context.Clone();

        //    Task.Factory.StartNew(() =>
        //    {
        //        try
        //        {
        //            Context.SetContext(clone);
        //            var scope = QueryHelpler.GetEntityScope(EntityTypes.InspectionRefType);
        //            var cacheKey = this.GetCacheKey(EntityTypes.I18NLanguages, null);
        //            var entity = this.BuildMobileEntity(scope, cacheKey, cacheData);
        //            this._inspectionRefTypeMECache.DeleteEntity(entity);
        //            this._inspectionRefTypeMECache.InsertEntity(entity);
        //        }
        //        catch (Exception ex)
        //        {
        //            try
        //            {
        //                Log.Error(ex, "ReferenceDataCache.CacheI18NLanguageSettings");
        //            }
        //            catch { }
        //        }
        //    });
        //}
    }
}
