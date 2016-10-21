using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accela.Apps.Apis.Models.DomainModels.PersistedDataModels;
using Accela.Apps.Apis.Persistence;
using Accela.Apps.Apis.Common;
using Accela.Apps.Apis.Repositories.Interfaces;
using Accela.Apps.Shared;

namespace Accela.Apps.Apis.Repositories.Agency
{
    public class PersistedDataRepository : RepositoryBase, IPersistedDataRepository
    {

        public PersistedDataRepository()
            : base() { }

        public List<PersistedDataModel> GetPersistedDatas(string agency)
        {
            using (var apiDataContext = new ApiDataContext(ConnectionStrings.ApiDB))
            {
                List<PersistedDataModel> persistedDataModels = new List<PersistedDataModel>();
                SqlRetryPolicy.ExecuteAction(() =>
                {
                    var persistedDatas = apiDataContext.PersistedDatas.Where(p => string.IsNullOrEmpty(agency) || p.Agency == agency).ToList();
                    if (persistedDatas != null && persistedDatas.Count > 0)
                    {
                        foreach (var persistedData in persistedDatas)
                        {
                            var persistedDataModel = new PersistedDataModel()
                            {
                                Id = persistedData.Id,
                                UserId = persistedData.UserId,
                                Agency = persistedData.Agency,
                                BlobName = persistedData.BlobName,
                                BlobSize = persistedData.BlobSize,
                                DataKey = persistedData.DataKey,
                                DateCreated = persistedData.DateCreated,
                                EntityType = persistedData.EntityType,
                                ExpirationDate = persistedData.ExpirationDate,
                                Name = persistedData.Name,
                                Namespace = persistedData.Namespace,
                                ProductName = persistedData.ProductName
                            };
                            persistedDataModels.Add(persistedDataModel);
                        }                        
                    }
                });
                return persistedDataModels;

            }
        }

        public bool DeletePersistedDatas(string agency, string entityType)
        {
            using (var apiDataContext = new ApiDataContext(ConnectionStrings.ApiDB))
            {
                var persistedDatas = apiDataContext.PersistedDatas.Where(p => (string.IsNullOrEmpty(agency) || p.Agency == agency) && (string.IsNullOrEmpty(entityType) || p.EntityType == entityType)).ToList();
                if(persistedDatas != null && persistedDatas.Count > 0)
                {
                    persistedDatas.ForEach(p => apiDataContext.PersistedDatas.Remove(p));
                    SqlRetryPolicy.ExecuteAction(() =>
                    {                        
                        apiDataContext.SaveChanges();
                    });
                }
            }
            return true;
        }
    }
}
