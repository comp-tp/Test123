using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Caching;
using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Models.DomainModels.Scope;
using Accela.Apps.Apis.Models.DTOs.Requests.ResourceRequests;
using Accela.Apps.Apis.Models.DTOs.Requests.ScopeRequests;
using Accela.Apps.Apis.Repositories.Interfaces;
using Accela.Apps.Shared;
using Accela.Infrastructure.Caches;
using Accela.Infrastructure.Configurations;

namespace Accela.Apps.Apis.BusinessEntities
{
    public class ScopeBusinessEntity : BusinessEntityBase, IScopeBusinessEntity
    {
        private const string RESOURCE_CACHE_EXPIRATION_MINUTES = "ResourceCacheExpirationMinutes";
        private readonly IScopeRepository ScopeRepository;
        private readonly IResourceBusinessEntity ResourceBusinessEntity;
        private readonly IMemoryCacheProvider cacheStoreProvider;
        private readonly IConfigurationReader _configurationReader;
        public ScopeBusinessEntity(IScopeRepository scopeRepository, IResourceBusinessEntity resourceBusinessEntity, IMemoryCacheProvider cacheStoreProvider, IConfigurationReader configurationReader)
        {
            this.ScopeRepository = scopeRepository;
            this.ResourceBusinessEntity = resourceBusinessEntity;
            this.cacheStoreProvider = cacheStoreProvider;
            this._configurationReader = configurationReader;
        }
        

        public bool IsValidScope(IsValidScopeRequest request)
        {
            bool result = false;

            // check condition
            if (request == null
                || request.ScopesInToken == null
                || request.ScopesInToken.Length == 0
                || String.IsNullOrWhiteSpace(request.RequestScope))
            {
                throw new Exception(Resources.MobileResources.GetString("input_parameter_invalid"));
            }

            // first validating scope
            if (request.ScopesInToken.Contains(request.RequestScope))
            {
                result = true;
            }

            // second validating
            if (!result)
            {
                var scopes = CachedScopes;

                if (scopes != null && scopes.Count > 0)
                {
                    var matchesLinq = from s in scopes
                                      where s != null
                                      && s.ScopeGroups != null
                                      from g in s.ScopeGroups
                                      where s.Name != null
                                      && s.Name == request.RequestScope
                                      && (request.ScopesInToken.Contains(s.Name)
                                        || (g != null && request.ScopesInToken.Contains(g.Name))
                                      )
                                      select g.Id;
                    result = matchesLinq.Count() > 0;
                }
            }

            return result;
        }

        public List<ScopeModel> GetScopes()
        {
            var result = CachedScopes;
            return result;
        }

        public List<string> GetScopesByGroup(string groupName)
        {
            List<string> scopes = new List<string>();

            // special group -- not grouped yet, put into an special group
            if (groupName == "not grouped")
            {
                foreach (var s in CachedScopes)
                {
                    if(s.ScopeGroups != null && s.ScopeGroups.Count == 0)
                    {
                        scopes.Add(s.Name);
                    }
                }
            }
            else
            {
                foreach (var s in CachedScopes)
                {
                    foreach (var g in s.ScopeGroups)
                    {
                        if (g.Name == groupName && !scopes.Contains(s.Name))
                        {
                            scopes.Add(s.Name);
                            break;
                        }
                    }
                }
            }

            return scopes;
        }

        public List<ScopeGroupModel> GetScopeGroups()
        {
            return CachedScopeGroups;
        }

        private string CACHE_KEY_Scopes = "CachedScopes";
        private string CACHE_KEY_ScopeGroups = "CachedScopeGroups";

        private List<ScopeModel> CachedScopes
        {
            get
            {
                List<ScopeModel> cachedScopes = null;

                try
                {
                    cachedScopes = cacheStoreProvider.Instance.Get(CACHE_KEY_Scopes) as List<ScopeModel>;
                }
                catch (Exception ex)
                {
                    Log.Critical(ex.Message, ex.ToString(), "CachedScopes-Get");
                }

                if (cachedScopes == null)
                {
                    var scopes = ScopeRepository.GetScopes();

                    if (scopes == null)
                    {
                        scopes = new List<ScopeModel>();
                    }

                    try
                    {
                        var cacheExpirationMinutes = _configurationReader.Get<double>(RESOURCE_CACHE_EXPIRATION_MINUTES, 15);
                        cacheStoreProvider.Instance.Put(CACHE_KEY_Scopes, scopes, DateTime.UtcNow.Add(TimeSpan.FromMinutes(cacheExpirationMinutes)));
                    }
                    catch(Exception ex)
                    {
                        Log.Critical(ex.Message, ex.ToString(), "CachedScopes-Put");
                    }
                    cachedScopes = scopes;
                }

                return cachedScopes;
            }
        }

        private List<ScopeGroupModel> CachedScopeGroups
        {
            get
            {
                List<ScopeGroupModel> result = null;
                try
                {
                    result = cacheStoreProvider.Instance.Get(CACHE_KEY_ScopeGroups) as List<ScopeGroupModel>;
                }
                catch(Exception ex)
                {
                    Log.Critical(ex.Message, ex.ToString(), "CachedScopeGroups-Get");
                }

                if (result == null)
                {
                    var scopeGroups = ScopeRepository.GetScopeGroups();

                    if (scopeGroups == null)
                    {
                        scopeGroups = new List<ScopeGroupModel>();
                    }

                    try
                    {
                        var cacheExpirationMinutes = _configurationReader.Get<double>(RESOURCE_CACHE_EXPIRATION_MINUTES, 15);
                        cacheStoreProvider.Instance.Put(CACHE_KEY_ScopeGroups, scopeGroups, DateTime.UtcNow.Add(TimeSpan.FromMinutes(cacheExpirationMinutes)));
                    }
                    catch (Exception ex)
                    {
                        Log.Critical(ex.Message, ex.ToString(), "CachedScopeGroups-Gut");
                    }
                    result = scopeGroups;
                }

                return result;
            }
        }
    }
}
