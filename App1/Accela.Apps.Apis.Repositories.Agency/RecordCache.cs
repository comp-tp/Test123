using System;
using Accela.Apps.Apis.Models.DomainModels.SummaryModels;
using Accela.Apps.Apis.Repositories.GovXmlHelpers;
using Accela.Apps.Apis.Repositories.Interfaces;
using Accela.Apps.Shared;
using Accela.Core.Ioc;
using Accela.Apps.Shared.Contexts;


namespace Accela.Apps.Apis.Repositories.Agency
{
    public class RecordCache : CacheBase
    {
        private IMobileEntityRepository<RecordSummaryModel> _recordSummaryCache;
        //private static IAgencyAppContext agencyAppContext = ServiceLocator.Resolve<IAgencyAppContext>();
        private static readonly RecordCache _instance = new RecordCache();

        /// <summary>
        /// Inspection cache class's structor.
        /// </summary>
        private RecordCache(): base()
        {
            _recordSummaryCache = IocContainer.Resolve<IMobileEntityRepository<RecordSummaryModel>>();
        }

        /// <summary>
        /// Get InpectionCache instance.
        /// </summary>
        public static RecordCache Instance
        {
            get
            {
                return _instance;
            }
        }

        /// <summary>
        /// Caches the record summary
        /// </summary>
        /// <param name="cloudUser">the cloud user.</param>
        /// <param name="inspectionTypes">The record summary information.</param>
        public void CacheRecordSummary(RecordSummaryModel recordSummary, string recordIdentifier, IAgencyAppContext agencyContext)
        {
            if (recordSummary != null)
            {
                var cacheData = JsonConverter.ToJson(recordSummary);
                var scope = QueryHelpler.GetEntityScope(EntityTypes.RecordSummary, agencyContext);
                var cacheKey = string.Format("{0}_{1}", "recordsummary", recordIdentifier);
                var entity = this.BuildMobileEntity(scope, cacheKey, cacheData);
                this._recordSummaryCache.DeleteEntity(entity);
                this._recordSummaryCache.InsertEntity(entity);
            }
        }

        public RecordSummaryModel GetRecordSummaryFromCache(string recordIdentifier, IAgencyAppContext agencyContext)
        {
            RecordSummaryModel result = null;

            if (agencyContext.ContextUser != null && !String.IsNullOrWhiteSpace(recordIdentifier))
            {
                var scope = QueryHelpler.GetEntityScope(EntityTypes.RecordSummary, agencyContext);
                var cacheKey = string.Format("{0}_{1}", "recordsummary", recordIdentifier);
                result = _recordSummaryCache.GetObjectById<RecordSummaryModel>(scope, cacheKey);
            }

            return result;
        }
    }
}
