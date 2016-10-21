using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.PersistedDataModels;

namespace Accela.Apps.Apis.WSModels.Caches
{
    [DataContract(Name="cache")]
    public class WSCache
    {
        [DataMember(Name="id", EmitDefaultValue = false)]
        public Guid Id { get; set; }

        [DataMember(Name = "userId", EmitDefaultValue = false)]
        public Guid? UserId { get; set; }

        [DataMember(Name = "namespace", EmitDefaultValue = false)]
        public string Namespace { get; set; }

        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(Name = "dataKey", EmitDefaultValue = false)]
        public string DataKey { get; set; }

        [DataMember(Name = "blobName", EmitDefaultValue = false)]
        public string BlobName { get; set; }

        [DataMember(Name = "expirationDate", EmitDefaultValue = false)]
        public DateTime ExpirationDate { get; set; }

        [DataMember(Name = "blobSize", EmitDefaultValue = false)]
        public Int64 BlobSize { get; set; }

        [DataMember(Name = "dateCreated", EmitDefaultValue = false)]
        public DateTime DateCreated { get; set; }

        [DataMember(Name = "productName", EmitDefaultValue = false)]
        public string ProductName { get; set; }

        [DataMember(Name = "agency", EmitDefaultValue = false)]
        public string Agency { get; set; }

        [DataMember(Name = "entityType", EmitDefaultValue = false)]
        public string EntityType { get; set; }

        public static WSCache FromEntityModel(PersistedDataModel persistedDataModel)
        {
            WSCache wsCache = null;
            if (persistedDataModel != null)
            {
                wsCache = new WSCache();
                wsCache.Agency = persistedDataModel.Agency;
                wsCache.BlobName = persistedDataModel.BlobName;
                wsCache.BlobSize = persistedDataModel.BlobSize;
                wsCache.DataKey = persistedDataModel.DataKey;
                wsCache.DateCreated = persistedDataModel.DateCreated;
                wsCache.EntityType = persistedDataModel.EntityType;
                wsCache.ExpirationDate = persistedDataModel.ExpirationDate;
                wsCache.Id = persistedDataModel.Id;
                wsCache.Name = persistedDataModel.Name;
                wsCache.Namespace = persistedDataModel.Namespace;
                wsCache.ProductName = persistedDataModel.ProductName;
                wsCache.UserId = persistedDataModel.UserId;
            }
            return wsCache;
        }

        public static List<WSCache> FromEntityModels(List<PersistedDataModel> persistedDataModels)
        {
            var caches = new List<WSCache>();
            if (persistedDataModels != null && persistedDataModels.Count > 0)
            {
                foreach (var persistedDataModel in persistedDataModels)
                {
                    caches.Add(FromEntityModel(persistedDataModel));
                }
            }
            return caches;
        }
    }
}
