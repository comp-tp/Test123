using System;
using System.Collections.Generic;
using System.Linq;
using Accela.Automation.GovXmlClient.Model;
using Accela.Apps.Shared;
using Accela.Apps.Shared.Contexts;
using Accela.Apps.Apis.Repositories.Interfaces;
using Accela.Apps.Apis.Models.DTOs.Requests.AssetRequests;
using Accela.Apps.Apis.Repositories.Agency.GovXmlHelpers;
using Accela.Infrastructure.Caches;

namespace Accela.Apps.Apis.Repositories.Agency
{
    /// <summary>
    /// Reference data repository class.
    /// </summary>
    public class StandardChoiceRepository : RepositoryBase, IStandardChoiceRepository
    {
  
        private CacheStoreProvider _cacheProvider;
        private IAgencyAppContext _contextEntity;

        public StandardChoiceRepository(IAgencyAppContext contextEntity, CacheStoreProvider cacheProvider)
            : base(contextEntity)
        {
            _cacheProvider = cacheProvider;
            _contextEntity = contextEntity;
        }

        /// <summary>
        /// language data like en-US, ex_Mx...
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public IList<string> GetI18NLanguageSettings(GetStandardChoicesRequest request, IAgencyAppContext agencyContext)
        {
            string key = String.Format("I18NSETTINGS_{0}_{1}",_contextEntity.Agency,_contextEntity.EnvName);
            var cachedLanguages = _cacheProvider.Instance.Get(key) as List<string>;
            var result = new List<string>();

            if (cachedLanguages == null || cachedLanguages.Count == 0)
            {
                CommonHelper.IsGettingI18NSetting = true;
                var govXmlIn = new GovXML
                {
                    getStandardChoices =
                        new GetStandardChoices
                        {
                            system = CommonHelper.GetSystem(request, agencyContext),
                            standardChoiceType = "I18N_LANGUAGES"
                        }
                };

                CommonHelper.IsGettingI18NSetting = false;

                try
                {
                    var response = CommonHelper.Post(govXmlIn,
                        govXmlIn.getStandardChoices.system,
                        (o) => o.getStandardChoicesResponse == null ? null : o.getStandardChoicesResponse.system);

                    var standardChoiseResult = StandardChoicesHelper.GetStandardChoices(response.getStandardChoicesResponse);

                    if (standardChoiseResult.StandardChoicesModels != null && standardChoiseResult.StandardChoicesModels.Count > 0)
                    {
                        standardChoiseResult.StandardChoicesModels.ForEach((t) => { result.Add(t.Id.Replace("_", "-")); });
                        _cacheProvider.Instance.Put(key, result, DateTime.UtcNow.AddDays(1));
                    }
                    else
                    {
                        result.Add(string.Empty); // per GovXML documentation, it's optional field
                        _cacheProvider.Instance.Put(key, result, DateTime.UtcNow.AddDays(1));
                    }
                }
                catch(Exception ex)
                {
                    Log.Error(ex, "GetI18NLanguageSettings");
                }

                return result;
            }
            else
            {
                return cachedLanguages;
            }
        }
    }
}
