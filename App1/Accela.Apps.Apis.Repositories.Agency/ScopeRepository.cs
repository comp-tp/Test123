using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accela.Apps.Apis.Repositories.Interfaces;
using Accela.Apps.Apis.Models.DomainModels.Scope;
using Accela.Apps.Apis.Persistence;
using Accela.Apps.Apis.Common;
using Accela.Apps.Shared;

namespace Accela.Apps.Apis.Repositories.Agency
{
    public class ScopeRepository : RepositoryBase, IScopeRepository
    {
        public ScopeRepository()
            : base() { 
        
        }

        public List<ScopeModel> GetScopes()
        {
            List<ScopeModel> result = null;

            using (var apiDataContext = new ApiDataContext(ConnectionStrings.ApiDB))
            {
                SqlRetryPolicy.ExecuteAction(() =>
                {
                    var resourceLinq = from r in apiDataContext.Resources
                                       where r != null
                                       select r.Name;

                    var scope2GroupLinq = from s2g in apiDataContext.Scope2Groups
                                          from sg in apiDataContext.ScopeGroups
                                          where s2g != null
                                          && sg != null
                                          && s2g.GroupID == sg.ID
                                          group sg by s2g.ScopeName into scopes
                                          select new
                                          {
                                              Name = scopes.Key,
                                              ScopeGroups = from s in scopes select s
                                          };
                    var scopeLinq = from r in resourceLinq
                                    select new
                                    {
                                        Name = r,
                                        ScopeGroups = from s2g in scope2GroupLinq
                                                      where s2g.Name == r
                                                      from g in s2g.ScopeGroups
                                                      select g
                                    };

                    var tempResult = scopeLinq.ToList();
                    if (tempResult.Count > 0)
                    {
                        result = new List<ScopeModel>();
                        tempResult.ForEach(p =>
                        {
                            var tempModel = new ScopeModel()
                            {
                                Name = p.Name,
                                ScopeGroups = ConvertToBizModels(p.ScopeGroups.ToList())
                            };
                            result.Add(tempModel);
                        });
                    }
                });
            }

            return result;
        }

        public List<ScopeGroupModel> GetScopeGroups()
        {
            List<ScopeGroupModel> result = null;

            List<ScopeGroup> scopeGroups = null;
            using (var apiDataContext = new ApiDataContext(ConnectionStrings.ApiDB))
            {
                SqlRetryPolicy.ExecuteAction(() =>
                {
                    scopeGroups = apiDataContext.ScopeGroups.ToList();
                });
            }

            result = ConvertToBizModels(scopeGroups);

            return result;
        }

        private List<ScopeGroupModel> ConvertToBizModels(List<ScopeGroup> dbModels)
        {
            List<ScopeGroupModel> result = null;

            if (dbModels != null)
            {
                result = new List<ScopeGroupModel>();
                dbModels.ForEach(p =>
                {
                    var tempModel = ConvertToBizModel(p);
                    result.Add(tempModel);
                });
            }

            return result;
        }

        private ScopeGroupModel ConvertToBizModel(ScopeGroup dbModel)
        {
            ScopeGroupModel result = null;

            if (dbModel != null)
            {
                result = new ScopeGroupModel()
                {
                    CreatedBy = dbModel.CreatedBy,
                    CreatedDate = dbModel.CreatedDate,
                    Description = dbModel.Description,
                    Id = dbModel.ID,
                    LastUpdatedBy = dbModel.LastUpdatedBy,
                    LastUpdatedDate = dbModel.LastUpdatedDate,
                    Name = dbModel.Name
                };
            }

            return result;
        }
    }
}
