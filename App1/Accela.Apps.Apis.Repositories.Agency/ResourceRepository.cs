using System.Collections.Generic;
using System.Linq;
using Accela.Apps.Apis.Models.DomainModels.ResourceModels;
using Accela.Apps.Apis.Persistence;
using Accela.Apps.Apis.Repositories.Interfaces;
using Accela.Apps.Apis.Common;
using System;
using Accela.Apps.Shared;
using Accela.Apps.Apis.Models.DTOs.Requests.ResourceRequests;

namespace Accela.Apps.Apis.Repositories.Agency
{
    public class ResourceRepository : RepositoryBase, IResourceRepository
    {
        public ResourceRepository()
            : base() { }

        public List<ResourceModel> GetResources()
        {
            var results = new List<ResourceModel>();

            using (var apiDataContext = new ApiDataContext(ConnectionStrings.ApiDB))
            {
                List<Accela.Apps.Apis.Persistence.Resource> resources = null;

                SqlRetryPolicy.ExecuteAction(() =>
                {
                    resources = apiDataContext.Resources.ToList();
                });

                if (resources != null)
                {
                    resources.ForEach(resource =>
                    {
                        results.Add(ToResourceModel(resource));
                    });
                }
            }

            return results;
        }

        /// <summary>
        /// Get resource model by resource id.
        /// </summary>
        /// <param name="resourceId">resource id(guid).</param>
        /// <returns>resource model.</returns>
        public ResourceModel GetResourceById(Guid resourceId)
        {
            ResourceModel result = null;
            Resource dbResult = null;
            using (var apiDataContext = new ApiDataContext(ConnectionStrings.ApiDB))
            {
                SqlRetryPolicy.ExecuteAction(() =>
                {
                    dbResult = apiDataContext.Resources.Where(r => r.Id == resourceId).FirstOrDefault();
                });
            }

            if (dbResult != null)
            {
                result = ToResourceModel(dbResult);
            }

            return result;
        }

        public List<ResourceModel> SaveResources(List<ResourceModel> resourcesRequest, bool updateResources)
        { 
        
            List<ResourceModel> result = new List<ResourceModel>();

            List<Resource> requestResources = new List<Resource>();
            foreach (ResourceModel resourceRequest in resourcesRequest)
            {
                Resource newResource = new Resource();
                newResource.API = resourceRequest.Api;
                newResource.HttpVerb = resourceRequest.HttpVerb;

                Resource dbResourceResult = null;

                if (resourceRequest.canSaveResource)
                {

                    newResource.RelativeUriTemplateFull = resourceRequest.UriTemplate;
                    newResource.Name = !String.IsNullOrWhiteSpace(resourceRequest.Name) ? resourceRequest.Name : resourceRequest.Api;
                    newResource.AuthenticationType = resourceRequest.AuthenticationType;
                    newResource.IsProxy = String.IsNullOrWhiteSpace(resourceRequest.ProxyAPI) ? 0 : 1;
                    newResource.ProxyAPI = resourceRequest.ProxyAPI;
                    newResource.ProxyRemoteServerName = resourceRequest.ProxyRemoteServerName;

                    using (var apiDataContext = new ApiDataContext(ConnectionStrings.ApiDB))
                    {
                        SqlRetryPolicy.ExecuteAction(() =>
                        {
                            if (updateResources)
                                dbResourceResult = apiDataContext.Resources.Where(r => (r.Id == resourceRequest.Id)).FirstOrDefault();
                            else
                                dbResourceResult = apiDataContext.Resources.Where(r => ((r.API.ToLower() == resourceRequest.Api.ToLower()) && (r.HttpVerb == resourceRequest.HttpVerb))).FirstOrDefault();

                            if (dbResourceResult == null)
                            {
                                if (!updateResources)
                                {
                                    newResource.Id = Guid.NewGuid();
                                    newResource.CreatedBy = "System";
                                    newResource.CreatedDate = DateTime.UtcNow;

                                    apiDataContext.Resources.Add(newResource);
                                }
                            }
                            else
                            {
                                dbResourceResult.RelativeUriTemplateFull = newResource.RelativeUriTemplateFull;
                                dbResourceResult.Name = newResource.Name;
                                dbResourceResult.AuthenticationType = newResource.AuthenticationType;
                                dbResourceResult.ProxyAPI = newResource.ProxyAPI;
                                dbResourceResult.ProxyRemoteServerName = dbResourceResult.ProxyRemoteServerName;
                                dbResourceResult.LastUpdatedBy = "System";
                                dbResourceResult.LastUpdatedDate = DateTime.UtcNow;

                                apiDataContext.Resources.Attach(dbResourceResult);

                                var updatedEntry = apiDataContext.Entry(dbResourceResult);
                                updatedEntry.Property(e => e.RelativeUriTemplateFull).IsModified = true;
                                updatedEntry.Property(e => e.Name).IsModified = true;
                                updatedEntry.Property(e => e.AuthenticationType).IsModified = true;
                                updatedEntry.Property(e => e.ProxyAPI).IsModified = true;
                                updatedEntry.Property(e => e.ProxyRemoteServerName).IsModified = true;
                                updatedEntry.Property(e => e.LastUpdatedBy).IsModified = true;
                                updatedEntry.Property(e => e.LastUpdatedDate).IsModified = true;

                            }
                            apiDataContext.SaveChanges();
                            
                        });
                    }

                    SaveScopeGroup(resourceRequest.Scope, resourceRequest.ScopeGroup);

                    if (dbResourceResult != null)
                    {
                        ResourceModel existingResourceModel = ToResourceModel(dbResourceResult);
                        existingResourceModel.canSaveResource = resourceRequest.canSaveResource;
                        existingResourceModel.resourceUpdated = true;
                        result.Add(existingResourceModel);
                    }
                    else
                    {
                        if (!updateResources)
                        {
                            ResourceModel newResourceModel = ToResourceModel(newResource);
                            newResourceModel.canSaveResource = resourceRequest.canSaveResource;
                            newResourceModel.resourceUpdated = true;
                            newResourceModel.resourceAdded = true;
                            result.Add(newResourceModel);
                        }
                    }
                }
                else
                    result.Add(resourceRequest);

            }
            

            return result;
        }

        private void SaveScopeGroup(string scope, string scopeGroup)
        {
            ScopeGroup dbScopegroupResult = null;
            Scope2Group dbScope2groupResult = null;


            ScopeGroup newScopeGroup = new ScopeGroup()
            {
                ID = Guid.NewGuid(),
                Name =scopeGroup,
                CreatedBy = "System",
                CreatedDate = DateTime.Now
            };

            using (var apiDataContext = new ApiDataContext(ConnectionStrings.ApiDB))
            {

                SqlRetryPolicy.ExecuteAction(() =>
                {
                    if (!String.IsNullOrWhiteSpace(scopeGroup))
                    {
                        dbScopegroupResult = apiDataContext.ScopeGroups.Where(r => (r.Name == scopeGroup)).FirstOrDefault();
                        if (dbScopegroupResult == null)
                        {
                            apiDataContext.ScopeGroups.Add(newScopeGroup);
                            apiDataContext.SaveChanges();
                        }
                    }

                    if (!String.IsNullOrWhiteSpace(scope) && !String.IsNullOrWhiteSpace(scopeGroup))
                    {
                        dbScope2groupResult = apiDataContext.Scope2Groups.Where(r => (r.ScopeName == scope)).FirstOrDefault();
                        if (dbScope2groupResult == null)
                        {
                            Scope2Group newScope2Group = new Scope2Group
                            {
                                ID = Guid.NewGuid(),
                                GroupID = dbScopegroupResult == null ? newScopeGroup.ID : dbScopegroupResult.ID,
                                ScopeName = scope,
                                CreatedBy = "System",
                                CreatedDate = DateTime.Now
                            };
                            apiDataContext.Scope2Groups.Add(newScope2Group);
                        }
                        else
                        {
                            dbScope2groupResult.GroupID = dbScopegroupResult == null ? newScopeGroup.ID : dbScopegroupResult.ID;
                            dbScope2groupResult.LastUpdatedBy = "System";
                            dbScope2groupResult.LastUpdatedDate = DateTime.Now;

                            apiDataContext.Scope2Groups.Attach(dbScope2groupResult);

                            var updatedEntry = apiDataContext.Entry(dbScope2groupResult);
                            updatedEntry.Property(e => e.GroupID).IsModified = true;
                            updatedEntry.Property(e => e.LastUpdatedBy).IsModified = true;
                            updatedEntry.Property(e => e.LastUpdatedDate).IsModified = true;
                        }
                        apiDataContext.SaveChanges();
                    }
                });
            }
        }

        public bool DeleteResource(Guid resourceId)
        {
            ResourceModel result = null;
            Resource dbResourceResult = null;
            using (var apiDataContext = new ApiDataContext(ConnectionStrings.ApiDB))
            {
                SqlRetryPolicy.ExecuteAction(() =>
                {
                    dbResourceResult = apiDataContext.Resources.Where(r => (r.Id == resourceId)).FirstOrDefault();
                    if (dbResourceResult != null)
                    {
                        apiDataContext.Resources.Remove(dbResourceResult);
                        apiDataContext.SaveChanges();
                    }
                });
            }

            if (dbResourceResult != null)
                return true;
            

            return false;
        }


        private ResourceModel ToResourceModel(Resource dbModel)
        {
            return new ResourceModel
            {
                Id = dbModel.Id,
                Api = dbModel.API,
                HttpVerb = dbModel.HttpVerb,
                UriTemplate = dbModel.RelativeUriTemplateFull,
                Name = dbModel.Name,
                AuthenticationType = dbModel.AuthenticationType,
                ProxyAPI = dbModel.ProxyAPI,
                IsProxy = dbModel.IsProxy,
                IsAAGovXMLAPI = dbModel.IsAAGovxmlAPI,
                Description = dbModel.Description,
                ProxyRemoteServerName = dbModel.ProxyRemoteServerName
            };
        }
    }
}
