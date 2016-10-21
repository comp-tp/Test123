using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accela.Apps.Apis.Models.DomainModels.PersistedDataModels
{
    public class PersistedDataModel
    {
        public Guid Id { get; set; }

        public Guid? UserId { get; set; }

        public string Namespace { get; set; }

        public string Name { get; set; }

        public string DataKey { get; set; }

        public string BlobName { get; set; }

        public DateTime ExpirationDate { get; set; }

        public Int64 BlobSize { get; set; }

        public DateTime DateCreated { get; set; }

        public string ProductName { get; set; }

        public string Agency { get; set; }

        public string EntityType { get; set; }
    }
}
